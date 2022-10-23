using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackupSystem
{
    public class Copying
    {
        static Queue<(string, string)> Birzha = new Queue<(string, string)>();
        //string - откуда
        //string - куда

        static Thread ThreadFullCheck, ThreadSrteamCopy;
        public static bool WannaWork = true;
        public static void WorkingStart()
        {
            // Здесь запускаем поток.
            ThreadFullCheck = new Thread(new ThreadStart(FullCheck));
            ThreadFullCheck.Start();
            ThreadSrteamCopy = new Thread(new ThreadStart(SrteamCopy));
            ThreadSrteamCopy.Start();
        }

        static bool FileChanged(string FileName, DateTime OldDate, long OldSize, string OldHash, out DateTime NewDate, out long NewSize, out string NewHash)
        {
            FileInfo inf = new FileInfo(FileName);
            NewSize = inf.Length;
            NewHash = FileMD5.LongFile(FileName);
            NewDate = File.GetLastWriteTime(FileName);
            if (!File.Exists(FileName)) return true;//Файла вообще не существует. 
            if (NewDate > OldDate)
            {
                if (NewSize == OldSize)
                {
                    //размер тот же. чекаем хэш
                    if (NewHash == OldHash)
                    {
                        //хэш совпал, файл не менялся.
                        return false;
                    }
                    else
                    {
                        //хэш разный. файл менялся.
                        return true;
                    }
                }
                else
                {
                    //размер другой. очевидно изменен.
                    return true;
                }
            }
            return false;
        }

        static void FullCheck()
        {
            while (WannaWork)
            {
                AddDatabase();
                WatchDog();
                Thread.Sleep(FormBackup.TimeWatchDog);
            }
        }

        static void AddDatabase()
        {
            for (int j = 0; j < JSONDatabase.ListCopying.Count; j++)
            {
                //это список физических файлов
                string From = JSONDatabase.ListCopying[j].DirectoryStart;
                List<string> ExistingActual = Directory.GetFiles(From, "*", SearchOption.AllDirectories).ToList();
                //а это из бд
                KeyValuePair<string, JSONDatabase.Files>[] ExistingDatabas = JSONDatabase.ListCopying[j].Files.ToArray();
                for (int i = 0; i < ExistingDatabas.Length; i++)
                {
                    KeyValuePair<string, JSONDatabase.Files> FileDifferences = ExistingDatabas[i];
                    //Console.WriteLine("чекаю файл: " + JSONDatabase.ListOfCopying[j].FromDir + file.Key);
                    ExistingActual.Remove(From + FileDifferences.Key);
                }
                for (int i = 0; i < ExistingActual.Count; i++)
                {
                    JSONDatabase.ListCopying[j].Files.Add(ExistingActual[i].Substring(From.Length), new JSONDatabase.Files()
                    {
                        Size = 0,
                        LastTimeChange = DateTime.MinValue,
                        Hash = ""
                    });
                }
            }
        }

        // Основной поток, который обращается к бд и чекает файлы на изменения.
        static void WatchDog()
        {
            for (int j = 0; j < JSONDatabase.ListCopying.Count; j++)
            {
                Console.WriteLine("чекаю " + JSONDatabase.ListCopying[j].DirectoryStart);
                KeyValuePair<string, JSONDatabase.Files>[] ListComponent = JSONDatabase.ListCopying[j].Files.ToArray();
                for (int i = 0; i < ListComponent.Length; i++)
                {
                    KeyValuePair<string, JSONDatabase.Files> FileCom = ListComponent[i];
                    Console.WriteLine("чекаю файл: " + JSONDatabase.ListCopying[j].DirectoryStart + FileCom.Key);
                    if (!FileCom.Value.IsIgnored && File.Exists(JSONDatabase.ListCopying[j].DirectoryStart + FileCom.Key) && FileChanged(JSONDatabase.ListCopying[j].DirectoryStart + FileCom.Key, FileCom.Value.LastTimeChange, FileCom.Value.Size, FileCom.Value.Hash,
                            out var newdate, out var newsize, out var newhash))
                    {
                        Console.WriteLine("он был изменен.");
                        JSONDatabase.Files Component = JSONDatabase.ListCopying[j].Files[FileCom.Key];
                        Component.LastTimeChange = newdate;
                        Component.Size = newsize;
                        Component.Hash = newhash;
                        JSONDatabase.ListCopying[j].Files[FileCom.Key] = Component;
                        JSONDatabase.JSONUpdates();
                        Birzha.Enqueue((JSONDatabase.ListCopying[j].DirectoryStart + FileCom.Key, JSONDatabase.ListCopying[j].DirectoryFinish + FileCom.Key));
                    }
                }
            }
        }
        static void SrteamCopy()
        {
            while (WannaWork)
            {
                if (FormBackup.StreamsFree > 0 && Birzha.Count > 0)
                {
                    (string, string) g = Birzha.Dequeue();
                    FormBackup.StreamsFree--;
                    Thread Thread = new Thread(new ParameterizedThreadStart(ThreadToCopy));
                    Thread.Start((object)(new string[] { g.Item1, g.Item2 }));
                }
            }

            void ThreadToCopy(object arg)
            {
                string[] DirectoryStartFinish = (arg as string[]);
                if (!Directory.Exists(Path.GetDirectoryName(DirectoryStartFinish[1])))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(DirectoryStartFinish[1]));
                }
                if (File.Exists(DirectoryStartFinish[1]))
                {
                    File.Delete(DirectoryStartFinish[1]);
                }
                File.Copy(DirectoryStartFinish[0], DirectoryStartFinish[1]);
                FormBackup.StreamsFree++;
            }

        }
    }
}

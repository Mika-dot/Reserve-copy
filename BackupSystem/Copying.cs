using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackupSystem
{
    public class Copying
    {
        static Queue<(string, string, int, string)> Birzha = new Queue<(string, string, int, string)>();
        //static Queue<(string, string)> BirzhaBackup = new Queue<(string, string)>();

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
                DeleteDatabase();
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
        
        static void DeleteDatabase()
        {
            for (int j = 0; j < JSONDatabase.ListCopying.Count; j++)
            {
                //это список физических файлов
                string From = JSONDatabase.ListCopying[j].DirectoryStart;
                string To = JSONDatabase.ListCopying[j].DirectoryFinish;
                //List<string> ExistingActual = Directory.GetFiles(From, "*", SearchOption.AllDirectories).ToList();
                //а это из бд
                KeyValuePair<string, JSONDatabase.Files>[] ExistingDatabas = JSONDatabase.ListCopying[j].Files.ToArray();
                bool b = false;
                for (int i = 0; i < ExistingDatabas.Length; i++)
                {
                    if (!File.Exists(From + ExistingDatabas[i].Key) && ExistingDatabas[i].Value.WasCopiedOnce)
					{
						JSONDatabase.ListCopying[j].Files.Remove(ExistingDatabas[i].Key);
                        b = true;
                        if (File.Exists(To + ExistingDatabas[i].Key)) File.Delete(To + ExistingDatabas[i].Key);
					}
                }
                if (b) JSONDatabase.JSONUpdates();
            }
        }
        

        // Основной поток, который обращается к бд и чекает файлы на изменения.
        static void WatchDog()
        {
            for (int j = 0; j < JSONDatabase.ListCopying.Count; j++)
            {
                if (JSONDatabase.ListCopying[j].LastTime.AddMinutes(JSONDatabase.ListCopying[j].Minutes) > DateTime.Now) continue;
                var c = JSONDatabase.ListCopying[j];
                c.LastTime = DateTime.Now;
                JSONDatabase.ListCopying[j] = c;
                Console.WriteLine("чекаю " + JSONDatabase.ListCopying[j].DirectoryStart);
                KeyValuePair<string, JSONDatabase.Files>[] ListComponent = JSONDatabase.ListCopying[j].Files.ToArray();
                for (int i = 0; i < ListComponent.Length; i++)
                {
                    KeyValuePair<string, JSONDatabase.Files> FileCom = ListComponent[i];
                    Console.WriteLine("чекаю файл: " + JSONDatabase.ListCopying[j].DirectoryStart + FileCom.Key);
                    if (!FileCom.Value.IsIgnored && File.Exists(JSONDatabase.ListCopying[j].DirectoryStart + FileCom.Key) &&
                        (FileChanged(JSONDatabase.ListCopying[j].DirectoryStart + FileCom.Key, FileCom.Value.LastTimeChange, FileCom.Value.Size, FileCom.Value.Hash,
                            out var newdate, out var newsize, out var newhash) || JSONDatabase.ListCopying[j].Files[FileCom.Key].StartedCopy))
                    {
                        Console.WriteLine("он был изменен.");
                        JSONDatabase.Files Component = JSONDatabase.ListCopying[j].Files[FileCom.Key];
                        Component.LastTimeChange = newdate;
                        Component.Size = newsize;
                        Component.Hash = newhash;
                        JSONDatabase.ListCopying[j].Files[FileCom.Key] = Component;
                        JSONDatabase.JSONUpdates();
                        //var n = j;
                        Birzha.Enqueue(
                            (JSONDatabase.ListCopying[j].DirectoryStart + FileCom.Key,
                            JSONDatabase.ListCopying[j].DirectoryFinish + FileCom.Key,
                            j, FileCom.Key
                            ));

                        //File.WriteAllLines("log.txt", Birzha.Select(x => x.From + "\n" + x.To + "\n").ToArray());
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
                    (string, string, int, string) g = Birzha.Dequeue();
                    FormBackup.StreamsFree--;
                    var c = JSONDatabase.ListCopying[g.Item3].Files[g.Item4];
                    c.StartedCopy = true;
                    JSONDatabase.ListCopying[g.Item3].Files[g.Item4] = c;
                    JSONDatabase.JSONUpdates();
                    Thread Thread = new Thread(new ParameterizedThreadStart(ThreadToCopy));
                    Thread.Start((object)(new object[] { g.Item1, g.Item2, g.Item3, g.Item4 }));
                }
            }

            void ThreadToCopy(object arg)
            {
                object[] DirectoryStartFinish = (arg as object[]);
                if (!Directory.Exists(Path.GetDirectoryName(DirectoryStartFinish[1].ToString())))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(DirectoryStartFinish[1].ToString()));
                }
                if (File.Exists(DirectoryStartFinish[1].ToString()))
                {
                    File.Delete(DirectoryStartFinish[1].ToString());
                }
                File.Copy(DirectoryStartFinish[0].ToString(), DirectoryStartFinish[1].ToString());
                var c = JSONDatabase.ListCopying[(int)DirectoryStartFinish[2]].Files[(string)DirectoryStartFinish[3]];
                c.StartedCopy = false;
                c.WasCopiedOnce = true;
                JSONDatabase.ListCopying[(int)DirectoryStartFinish[2]].Files[(string)DirectoryStartFinish[3]] = c;
                JSONDatabase.JSONUpdates();
                FormBackup.StreamsFree++;
            }

        }
    }
}

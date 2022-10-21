using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BackupSystem.JSONDatabase;

namespace BackupSystem
{
    public class JSONDatabase : JSONUInteraction
    {
        public static List<CopyFolder> ListCopying = new List<CopyFolder>();

        public static void CopyMessage(string DirectoryStart, string DirectoryFinish)
        {
            string[] FilesCopy = Directory.GetFiles(DirectoryStart, "*", SearchOption.AllDirectories);
            for (int i = 0; i < FilesCopy.Length; i++)
            {
                string FileCopy = FilesCopy[i].Substring(DirectoryStart.Length);
                Console.WriteLine("Копируем файл: " + FileCopy);
                if (!File.Exists(DirectoryFinish + FileCopy))
                {
                    File.Copy(DirectoryStart + FileCopy, DirectoryFinish + FileCopy);
                }
            }

        }
        public static void UpdateCatalogLatest(string DirectoryStart, string DirectoryFinish)
        {
            string[] Folders = Directory.GetDirectories(DirectoryStart, "*", SearchOption.AllDirectories);
            for (int i = 0; i < Folders.Length; i++)
            {
                string Folder = Folders[i].Substring(DirectoryStart.Length);
                Console.WriteLine("Нужная поддиректория: " + Folder);
                if (!Directory.Exists(DirectoryFinish + Folder))
                {
                    Directory.CreateDirectory(DirectoryFinish + Folder);
                }
            }
        }
        public static CopyFolder InitNewPair(string FileName, string DirectoryStart, string DirectoryFinish)
        {
            UpdateCatalogLatest(DirectoryStart, DirectoryFinish);
            string[] Folders = Directory.GetFiles(DirectoryStart, "*", SearchOption.AllDirectories);
            CopyFolder Cell = new CopyFolder();
            Cell.Name = FileName;
            Cell.DirectoryStart = DirectoryStart;
            Cell.DirectoryFinish = DirectoryFinish;
            Cell.Files = new Dictionary<string, Files>();
            for (int i = 0; i < Folders.Length; i++)
            {
                FileInfo FileOptions = new FileInfo(Folders[i]);
                Cell.Files.Add(Folders[i].Substring(DirectoryStart.Length), new Files()
                {
                    Size = FileOptions.Length,
                    Hash = FileMD5.LongFile(Folders[i]),
                    LastTimeChange = FileOptions.LastWriteTime
                });
            }
            ListCopying.Add(Cell);
            CopyMessage(DirectoryStart, DirectoryFinish);
            JSONUpdates();
            return Cell;
        }

        // 
        public static void RemoveDependencies(int NumberSerial)
        {
            ListCopying.RemoveAt(NumberSerial);
            JSONUpdates();
        }
        public struct CopyFolder
        {
            [JsonProperty]
            public string Name, DirectoryStart, DirectoryFinish;
            [JsonProperty]
            public Dictionary<string, Files> Files;
        }
        public struct Files
        {
            [JsonProperty]
            public long Size;
            [JsonProperty]
            public string Hash;
            [JsonProperty]
            public DateTime LastTimeChange;
        }
    }

}

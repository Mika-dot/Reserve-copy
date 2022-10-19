using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copying
{
    public class Sync
    {
        public static void SyncDir(string FromDir, string ToDir)
        {
            Directory.CreateDirectory(ToDir);

            foreach (string s1 in Directory.GetFiles(ToDir))
            {
                string s2 = FromDir + "\\" + Path.GetFileName(s1);
                if (!File.Exists(s2))
                {
                    Console.WriteLine("Deleting file^ {0}", s1); // закомментить если не нужен вывод в консоль либо заменить на вывод куда нужно
                    File.Delete(s1);
                }
            }

            foreach (string s1 in Directory.GetFiles(FromDir))
            {
                string s2 = ToDir + "\\" + Path.GetFileName(s1);
                if (!File.Exists(s2))
                {
                    File.Copy(s1, s2);
                }
                else
                {
                    FileInfo fi1 = new FileInfo(s1);
                    FileInfo fi2 = new FileInfo(s2);
                    if (fi1.LastWriteTime != fi2.LastWriteTime)
                    {
                        File.Delete(s2);
                        File.Copy(s1, s2);
                        Console.WriteLine("Update file {0} from file {1}", s1, s2); // закомментить если не нужен вывод в консоль либо заменить на вывод куда нужно
                    }
                }
            }

            foreach (string s in Directory.GetDirectories(FromDir))
            {
                SyncDir(s, ToDir + "\\" + Path.GetFileName(s));
                Console.WriteLine(s); // закомментить если не нужен вывод в консоль либо заменить на вывод куда нужно
            }
        }
    }
}

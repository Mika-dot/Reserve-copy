using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InvisibleFile
{
    public class Hidden
    {
        public static bool Creation(string path)
        {
			try
			{
                File.Delete(path);
                File.Create(path);
                File.SetAttributes(path, FileAttributes.Hidden);
            }
            catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public static List<(string Name, string FullName, long Length, DateTime CreationTime)>? FindFile(string path, string file)
        {
            List<(string Name, string FullName, long Length, DateTime CreationTime)> Files = new List<(string Name, string FullName, long Length, DateTime CreationTime)>();
            try
            {
                foreach (string findedFile in Directory.EnumerateFiles(path, file, SearchOption.AllDirectories))
                {
                    FileInfo FI;
                    try
                    {  
                        FI = new FileInfo(findedFile);

                        //найденный результат выводим в консоль (имя, путь, размер, дата создания файла)
                        Console.WriteLine(FI.Name + " " + FI.FullName + " " + FI.Length + "_байт" +
                            " Создан: " + FI.CreationTime);
                        Files.Add(new (FI.Name, FI.FullName, FI.Length, FI.CreationTime));
                    }
                    catch
                    {
                        continue;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return Files;
        }
    }
}

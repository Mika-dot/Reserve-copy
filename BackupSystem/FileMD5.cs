using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BackupSystem
{
    public class FileMD5
    {
        public static string File512(string path)
        {
            using (FileStream Files = System.IO.File.OpenRead(path))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] FileData = new byte[Files.Length];
                Files.Read(FileData, 0, (int)Files.Length);
                byte[] CheckSum = md5.ComputeHash(FileData);
                string Result = BitConverter.ToString(CheckSum).Replace("-", String.Empty);
                return Result;
            }
        }
        public static string LongFile(string path)
        {
            using (MD5 md5 = MD5.Create())
            {
                using (FileStream Stream = File.OpenRead(path))
                {
                    string Result = BitConverter.ToString(md5.ComputeHash(Stream)).Replace("-", String.Empty);
                    return Result;
                }
            }
        }
    }
}

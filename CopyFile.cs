using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CopyFile
{
    public static class CopyFileD
    {
        public static bool CopyDelete(string path, string newPath)
        {
            try
            {
                FileInfo fileOld = new FileInfo(path);
                FileInfo fileNew = new FileInfo(newPath);
                fileNew.Delete();
                fileOld.CopyTo(newPath, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public static bool CopyOverwriting(string path, string newPath)
        {
            try
            {
                FileInfo fileOld = new FileInfo(path);
                fileOld.CopyTo(newPath, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

    }
}

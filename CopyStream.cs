using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferStream
{
    public class CopyStream
    {
        public static bool CopyStreamFolder(string[] path)
        {
            try
            {
                Thread myThread = new Thread(CopyStream);

                myThread.Start(new string[] { path[0], path[1] });

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }


            void CopyStream(object? obj)
            {
                if (obj is string[] path)
                {
                    Sync.SyncDir(path[0], path[1]);
                }

            }
        }
    }
}

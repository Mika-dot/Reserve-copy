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
    public class JSONUInteraction
    {
        public static void JSONUnload()
        {
            if (!File.Exists("database.json"))
            {
                File.WriteAllText("database.json", "[]");
            }
            ListCopying = JsonConvert.DeserializeObject<List<CopyFolder>>(File.ReadAllText("database.json"));
            for (int i = 0; i < ListCopying.Count; i++)
            {
                //Form1.comboBox1.Items.Add(ListCopying[i].Name); // допилить
            }
        }
        public static void JSONUpdates()
        {
            File.WriteAllText("database.json", JsonConvert.SerializeObject(ListCopying, Formatting.Indented));
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackupSystem
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            jsonDATABASE.LoadJSON();
            Copying.StartWorking();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) textBox1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) textBox2.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show($"Выберите директорию, откуда копировать!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox2.Text.Length == 0)
            {
                MessageBox.Show($"Выберите директорию, куда копировать!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox3.Text.Length == 0)
            {
                MessageBox.Show($"Назовите как-нибудь пару!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(textBox1.Text))
            {
                MessageBox.Show($"Папки {textBox1.Text} не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(textBox2.Text))
            {
                Directory.CreateDirectory(textBox2.Text);
                //MessageBox.Show($"Папки {textBox2.Text} не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }
            var t = jsonDATABASE.ListOfCopying.Find(x => x.Name == textBox3.Text);
            if (t.Name == textBox3.Text)
            {
                MessageBox.Show($"Пара {textBox3.Text} уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox1.Text[textBox1.TextLength - 1] != '\\') textBox1.Text += '\\';
            if (textBox2.Text[textBox2.TextLength - 1] != '\\') textBox2.Text += '\\';
            jsonDATABASE.InitNewPair(textBox3.Text, textBox1.Text, textBox2.Text);
            MessageBox.Show($"Пара '{textBox3.Text}' создана.");
            textBox1.Text = textBox2.Text = textBox3.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var N = comboBox1.SelectedIndex;
                jsonDATABASE.DeletePair(N);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var n = comboBox1.SelectedIndex;
            label6.Text = n == -1 ? "..." : jsonDATABASE.ListOfCopying[n].FromDir;
            label7.Text = n == -1 ? "..." : jsonDATABASE.ListOfCopying[n].ToDir;
            button4.Enabled = n > -1;
        }
    }

    internal class FileMD5
    {
        public static string File512(string path)
        {
            using (FileStream fs = System.IO.File.OpenRead(path))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                byte[] checkSum = md5.ComputeHash(fileData);
                string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                return result;
            }
        }
        public static string LongFile(string path)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    string result = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", String.Empty);
                    return result;
                }
            }
        }
    }

    class Copying
    {
        static Queue<(string, string)> BIRZHA = new Queue<(string, string)>();
        //string - откуда
        //string - куда

        static Thread th, th2;

        public static void StartWorking()
        {
            // Здесь запускаем поток.
            //th = new Thread(new ThreadStart(CHECKER));
            //th.Start();
            th2 = new Thread(new ThreadStart(subThreads));
            th2.Start();
        }
        /*
        static bool FileChanged(string filename, DateTime olddate, long oldsize, string oldhash, out DateTime newdate, out long newsize, out string newhash)
        {
            FileInfo inf = new FileInfo(filename);
            newsize = inf.Length;
            newhash = FileMD5.LongFile(filename);
            newdate = File.GetLastWriteTime(filename);
            if (!File.Exists(filename)) return true;//Файла вообще не существует. 
            if (newdate > olddate)
            {
                if (newsize == oldsize)
                {
                    //размер тот же. чекаем хэш
                    if (newhash == oldhash)
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
        */
        // Основной поток, который обращается к бд и чекает файлы на изменения.
        /*
        static void CHECKER()
        {
            while (true)
            {
                for (int j = 0; j < jsonDATABASE.ListOfCopying.Count; j++)
                {
                    Console.WriteLine("чекаю " + jsonDATABASE.ListOfCopying[j].FromDir);
                    var arr = jsonDATABASE.ListOfCopying[j].Files.ToArray();
                    for (int i = 0; i < arr.Length; i++)
                    {
                        var file = arr[i];
                        Console.WriteLine("чекаю файл: " + jsonDATABASE.ListOfCopying[j].FromDir + file.Key);
                        if (FileChanged(jsonDATABASE.ListOfCopying[j].FromDir + file.Key, file.Value.LastChange, file.Value.Size, file.Value.Hash,
                                out var newdate, out var newsize, out var newhash))
                        {
                            Console.WriteLine("он был изменен.");
                            var s = jsonDATABASE.ListOfCopying[j].Files[file.Key];
                            s.LastChange = newdate;
                            s.Size = newsize;
                            s.Hash = newhash;
                            jsonDATABASE.ListOfCopying[j].Files[file.Key] = s;
                            jsonDATABASE.SaveJSON();
                            BIRZHA.Enqueue((jsonDATABASE.ListOfCopying[j].FromDir + file.Key, jsonDATABASE.ListOfCopying[j].ToDir + file.Key));
                        }
                    }
                }
                // Это должны были быть пары (откуда-куда)
                //(int id, string from, string to)[] Pairs = new (int, string, string)[32];
                for (int j = 0; j < Pairs.Length; j++)
                {
                    // Берем на основании id (из Pairs) новые данные - список файло
                    //(string name, DateTime date, long size, string hash)[] Datas = new (string, DateTime, long, string)[16];

                    for (int i = 0; i < Datas.Length; i++)
                    {
                        // берем конкретную строчку и чекаем ее - смотрим на данные физического файла
                        //и сверяем с данными из бд.
                        //т.к. имя файла в бд хранится относительное (относительно корневого каталога)
                        //то пишется "Pairs[j].from + " или "Pairs[j].to + "
                        if (FileChanged(Pairs[j].from + Datas[i].name, Datas[i].date, Datas[i].size, Datas[i].hash,
                            out var newdate, out var newsize, out var newhash))
                        {
                            // Файл был изменен. Добавляем пути файлов в биржу, чтоб они потом скопировались.
                            BIRZHA.Enqueue((Pairs[j].from + Datas[i].name, Pairs[j].to + Datas[i].name));
                            //Console.WriteLine("новая дата: " + newdate);
                            //Console.WriteLine("новый размер: " + newsize);
                            //Console.WriteLine("новый хэш: " + newhash);
                        }

                    }

                }
                Thread.Sleep(5000);
            }
        }
        */

        static int FreeThreads = 5; // Количество свободных подпотоков.
                                    // Это ещё один поток. Он может сразу же, как в основном потоке заполнится биржа,
                                    //взять из биржи что-то и начать копировать - не дожидаясь, пока чекер пройдется
                                    // по другим файлам (их может быть много)
        static void subThreads()
        {
            while (true)
            {
                if (FreeThreads > 0 && BIRZHA.Count > 0)
                {
                    var g = BIRZHA.Dequeue();
                    FreeThreads--;
                    var thr = new Thread(new ParameterizedThreadStart(threadToCopy));
                    thr.Start((object)(new string[] { g.Item1, g.Item2 }));
                }
            }

            void threadToCopy(object arg)
            {
                var ss = (arg as string[]);
                if (File.Exists(ss[1])) File.Delete(ss[1]);
                File.Copy(ss[0], ss[1]);
                FreeThreads++;
            }

        }

        public static FileSystemWatcher CreateWatcher(int N, string dir)
        {
            var fsw = new FileSystemWatcher(dir);
            fsw.Changed += OnChanged;
            fsw.Created += OnCreated;
            fsw.Deleted += OnDeleted;
            fsw.Renamed += OnRenamed;
            void OnChanged(object sender, FileSystemEventArgs e) => MessageBox.Show($"Changed: {e.FullPath}");
            void OnCreated(object sender, FileSystemEventArgs e) => MessageBox.Show($"Created: {e.FullPath}");
            void OnDeleted(object sender, FileSystemEventArgs e) => MessageBox.Show($"Deleted: {e.FullPath}");
            void OnRenamed(object sender, RenamedEventArgs e) => MessageBox.Show($"Renamed: {e.OldFullPath} {e.FullPath}");
            return fsw;
        }

    }

    class jsonDATABASE
    {
        public static List<CopyCell> ListOfCopying = new List<CopyCell>();

        public static void LoadJSON()
        {
            if (!File.Exists("database.json")) File.WriteAllText("database.json", "[]");
            ListOfCopying = JsonConvert.DeserializeObject<List<CopyCell>>(File.ReadAllText("database.json"));
            for (int i = 0; i < ListOfCopying.Count; i++)
            {
                var c = ListOfCopying[i];
                c.fsw = Copying.CreateWatcher(i, c.FromDir);
                ListOfCopying[i] = c;
                Form1.comboBox1.Items.Add(c.Name);
            }
        }

        public static void SaveJSON() => File.WriteAllText("database.json", JsonConvert.SerializeObject(ListOfCopying, Formatting.Indented));

        // Не дописано
        public static void FULLCopy(string From, string To, bool TotalRewrite = false)
        {
            var files = Directory.GetFiles(From, "*", SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; i++)
            {
                var file = files[i].Substring(From.Length);
                Console.WriteLine("Копируем файл: " + file);
                if (!File.Exists(To + file))
                {
                    File.Copy(From + file, To + file);
                }
                else
                {
                    if (TotalRewrite)
                    {

                    }
                }
            }

        }
        static void UpdateTODirs(string From, string To)
        {
            var dirs = Directory.GetDirectories(From, "*", SearchOption.AllDirectories);
            for (int i = 0; i < dirs.Length; i++)
            {
                var dir = dirs[i].Substring(From.Length);
                Console.WriteLine("Нужная поддиректория: " + dir);
                if (!Directory.Exists(To + dir)) Directory.CreateDirectory(To + dir);
            }
        }
        public static CopyCell InitNewPair(string Name, string From, string To)
        {
            UpdateTODirs(From, To);
            var files = Directory.GetFiles(From, "*", SearchOption.AllDirectories);
            var cell = new CopyCell();
            cell.Name = Name;
            cell.FromDir = From;
            cell.ToDir = To;
            cell.Files = new Dictionary<string, FileS>();
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo inf = new FileInfo(files[i]);
                cell.Files.Add(files[i].Substring(From.Length), new FileS()
                {
                    Size = inf.Length,
                    Hash = FileMD5.LongFile(files[i]),
                    LastChange = inf.LastWriteTime
                });
            }
            cell.fsw = Copying.CreateWatcher(ListOfCopying.Count, From);
            ListOfCopying.Add(cell);
            Form1.comboBox1.Items.Add(Name);
            FULLCopy(From, To);
            SaveJSON();
            return cell;
        }

        public static void DeletePair(int N)
        {
            Form1.comboBox1.Items.RemoveAt(N);
            ListOfCopying[N].fsw.Dispose();
            ListOfCopying.RemoveAt(N);
            SaveJSON();
        }

        public struct CopyCell
        {
            public FileSystemWatcher fsw;
            [JsonProperty]
            public string Name, FromDir, ToDir;
            [JsonProperty]
            public Dictionary<string, FileS> Files;
        }
        public struct FileS
        {
            [JsonProperty]
            public long Size;
            [JsonProperty]
            public string Hash;
            [JsonProperty]
            public DateTime LastChange;
        }
    }

}

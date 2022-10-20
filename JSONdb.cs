using Md5;
using Newtonsoft.Json;

class jsonDATABASE
{
    public static List<CopyCell> ListOfCopying = new List<CopyCell>();

    public static void LoadJSON() => ListOfCopying = JsonConvert.DeserializeObject<List<CopyCell>>(File.ReadAllText("database.json"));

    public static void SaveJSON() => File.WriteAllText("database.json", JsonConvert.SerializeObject(ListOfCopying, Formatting.Indented));

    // Не дописано
    public static void FULLCopy(string From, string To, bool TotalRewrite = false)
    {
        var files = Directory.GetFiles(From, "", SearchOption.AllDirectories);
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
        var dirs = Directory.GetDirectories(From, "", SearchOption.AllDirectories);
        for (int i = 0; i < dirs.Length; i++)
        {
            var dir = dirs[i].Substring(From.Length);
            Console.WriteLine("Нужная поддиректория: " + dir);
            if (!Directory.Exists(To + dir)) Directory.CreateDirectory(To + dir);
        }
    }
    public static CopyCell InitNewPair(string From, string To)
    {
        UpdateTODirs(From, To);
        var files = Directory.GetFiles(From, "", SearchOption.AllDirectories);
        var cell = new CopyCell();
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
        return cell;
    }

    public static void DeletePair(int N) => ListOfCopying.RemoveAt(N);

    public struct CopyCell
    {
        [JsonProperty]
        public string FromDir, ToDir;
        [JsonProperty]
        public Dictionary<string, FileS> Files;
    }
    public struct FileS
    {
        [JsonProperty]
        public long Size;
        [JsonProperty]
        public long Hash;
        [JsonProperty]
        public DateTime LastChange;
    }
}
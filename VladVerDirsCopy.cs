Copy("C:\\Users\\TrushinVlad\\Desktop\\Avatar", "C:\\Users\\TrushinVlad\\Desktop\\Avatar2");

void Copy(string From, string To)
{
    var dt1 = DateTime.Now;
    var dirs = Directory.GetDirectories(From, "", SearchOption.AllDirectories);
    for (int i = 0; i < dirs.Length; i++)
    {
        var dir = dirs[i].Substring(From.Length);
        Console.WriteLine("Нужная поддиректория: " + dir);
        if (!Directory.Exists(To + dir)) Directory.CreateDirectory(To + dir);
    }

    var files = Directory.GetFiles(From, "", SearchOption.AllDirectories);
    for (int i = 0; i < files.Length; i++)
    {
        var file = files[i].Substring(From.Length);
        Console.WriteLine("Копируем файл: " + file);
        if (!File.Exists(To + file)) File.Copy(From + file, To + file);
    }

    var dt2 = DateTime.Now;
    Console.WriteLine(dt2 - dt1);
    Console.ReadKey();
}
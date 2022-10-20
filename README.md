# Проверка изменения файлов

Передаем путь к файлу, время последненго изменения, размер и хеш файла.
```C#
  if (FileChanged(
    @"Путь", new DateTime(978654453646), 634344, "1BC29B36F623BA82AAF6724FD3B16718", 
    out var newdate, out var newsize, out var newhash))
{
    Console.WriteLine("новая дата: " + newdate);
    Console.WriteLine("новый размер: " + newsize);
    Console.WriteLine("новый хэш: " + newhash);
}
```


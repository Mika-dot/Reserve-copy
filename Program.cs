if (FileChanged("C:\\Users\\TrushinVlad\\Desktop\\Avatar\\index.html",
    new DateTime(978654453646), 634344, "1BC29B36F623BA82AAF6724FD3B16718", out var newdate, out var newsize, out var newhash))
{
    Console.WriteLine("новая дата: " + newdate);
    Console.WriteLine("новый размер: " + newsize);
    Console.WriteLine("новый хэш: " + newhash);
}
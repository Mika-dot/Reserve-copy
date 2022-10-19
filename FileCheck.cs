using Md5;

bool FileChanged(string filename, DateTime olddate, long oldsize, string oldhash, out DateTime newdate, out long newsize, out string newhash)
{
    newsize = 0;
    newhash = "";
    newdate = File.GetLastWriteTime(filename);
    if (newdate > olddate)
    {
        FileInfo inf = new FileInfo(filename);
        newsize = inf.Length;
        if (newsize == oldsize)
        {
            newhash = FileMD5.LongFile(filename);
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

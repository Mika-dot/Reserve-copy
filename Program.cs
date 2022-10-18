using Md5;

string thisFileMD5 = FileMD5.Start2(@"C:\Users\akimp\OneDrive\Рабочий стол\Cad-OpenGL — копия\OpenGL_lesson_CSharp\OpenGL_lesson_CSharp\SharpGLForm.cs");
Console.WriteLine("md5 : " + thisFileMD5);
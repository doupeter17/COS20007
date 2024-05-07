using System;
using SplashKitSDK;

namespace TestSemester1
{
    public class Program
    {
        
        public static void Main()
        {
            TestSemester1.File file1, file2, file3;
            TestSemester1.Folder folder1, folder2, folder3;
            FileSystem system1;
            
            file1 = new TestSemester1.File("Taylor Swift", "mp3", 1034);
            file2 = new TestSemester1.File("Palworld", "exe", 122123);
            file3 = new TestSemester1.File("Pokemon", "jpg", 123);
            
            folder1 = new Folder("My Music");
            folder1.Add(file1);
            folder1.Add(file3);
            folder2 = new Folder("My Game");

            folder3 = new Folder("My entertaining");
            folder3.Add(folder1);

            system1 = new FileSystem();
            system1.Add(folder1);
            system1.Add(folder2);
            system1.Add(folder3);
            system1.Add(file2);

            system1.PrintContent();
        }
    }
}

using TestSemester1;
namespace FileSystemTest
{
    public class Tests
    {
        TestSemester1.File file1, file2, file3;
        TestSemester1.Folder folder1, folder2;
        FileSystem system1;
        [SetUp]
        
        public void Setup()
        {
            file1 = new TestSemester1.File("Taylor Swift", "mp3", 1034);
            file2 = new TestSemester1.File("Palworld", "exe", 122123);
            file3 = new TestSemester1.File("Pokemon", "jpg", 123);
            folder1 = new Folder("My Music");
            folder1.Add(file1);
            folder1.Add(file2);
            folder1.Add(file3);
            folder2 = new Folder("My Game");
            system1 = new FileSystem();
            system1.AddFolder(folder1);
            system1.AddFolder(folder2);

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
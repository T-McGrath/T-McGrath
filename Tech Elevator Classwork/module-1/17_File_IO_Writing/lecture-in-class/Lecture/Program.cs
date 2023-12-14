using System;
using Lecture.Aids;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            WritingTextFiles.WritingAFile();
            PerformanceDemo.FastPerformance();
            PerformanceDemo.SlowPerformance();
            FilePaths.UsingPathToCombineTwoFilePaths();
            FilePaths.UsingPathForTemporaryFolders();
            Console.Write("Press enter to finish");
            Console.ReadLine();
        }
    }
}

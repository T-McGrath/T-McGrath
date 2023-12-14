using System;
using System.IO;

namespace Lecture.Aids
{
    public static class WritingTextFiles
    {
        /*
        * This method below provides sample code for printing out a message to a text file.
        */
        public static void WritingAFile()
        {
            string directory = Environment.CurrentDirectory;
            string directoryAgain = Directory.GetCurrentDirectory();
            string filename = "Foxy.txt";
            //string theDirectoryIWantToNavigateTo = $"..\\..\\..{directory}";
            string goUpInDirectories = Path.Combine("..\\..\\..", Environment.CurrentDirectory);
            //string fullPath = Path.Combine(theDirectoryIWantToNavigateTo, filename);
            string relativePath = Path.GetRelativePath("..\\..\\..", Environment.CurrentDirectory);
            using (StreamWriter writer = new StreamWriter("..\\..\\..\\Foxy2.txt", false))
            {
                writer.WriteLine("Woof");
                writer.WriteLine();
                writer.Write("Woof");
                writer.Write("Woof");
                // Prints blank line
                writer.WriteLine();

                // Prints
                // Tech
                // Elevator
                writer.WriteLine("Tech");
                writer.WriteLine("Elevator");

                // Prints the current datetime
                writer.WriteLine(DateTime.UtcNow);


            }

            // After the using statement ends, file has now been written
            // and closed for further writing
        }
    }
}

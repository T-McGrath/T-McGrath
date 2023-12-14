using System;
using System.IO;

namespace FileIOReadingTutorial
{
    class Program
    {
        private const string BEGIN_MARKER = "*** START OF";
        private const string END_MARKER = "*** END OF";
        static void Main(string[] args)
        {
             /*
             * This book-reader program opens a file that was downloaded from https://www.gutenberg.org/, reads
             * through the copyright information at the top until it finds the start of the book content, and
             * then displays the content to the user. It also counts the total lines of book content between the
             * start and the end markers.
             */

            /*
            Step 1: Prompt the user for a filename
             */
            // Prompt the user for a file path - path should look like "data/jekyll-and-hyde.txt"
            Console.Write("Enter path to the book file: ");
            string filePath = Console.ReadLine();

            /*
            Step 2: Step Two: Open the book file and handle errors
            */
            bool wasPreviousLineBlank = false;
            bool inBookText = false; // Are you reading between the start and end markers?
            int lineCount = 0;
            try
            {
                using (StreamReader fileInput = new StreamReader(filePath))
                {
                    /*
                     Step 3: Create a read loop and process the lines.
                    */
                    // Loop until the end of the file is reached
                    while (!fileInput.EndOfStream)
                    {
                        // Read the next line into 'lineOfText'
                        string lineOfText = fileInput.ReadLine();
                        /*
                         * Step 4: Skip the header info before the book content.
                         */
                        if (lineOfText.StartsWith(BEGIN_MARKER))
                        {
                            inBookText = true;
                            continue;// Skip everything else and start at the beginning of the loop.
                        }
                        if (lineOfText.StartsWith(END_MARKER))
                        {
                            break; // When we get to the end of the stuff we care about, end the loop.
                        }
                        if (inBookText) // Only do this stuff if the line is part of the actual story.
                        {
                            if (lineOfText == "" && !wasPreviousLineBlank) 
                            {
                                wasPreviousLineBlank = true;
                                lineCount++;
                                Console.WriteLine($"{lineCount}: {lineOfText}");
                            }
                            else if (lineOfText != "")
                            {
                                wasPreviousLineBlank = false;
                                lineCount++;
                                Console.WriteLine($"{lineCount}: {lineOfText}");
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            // Tell the user how many lines of content were found.
            Console.WriteLine($"Found {lineCount} lines of text in {filePath}");
        }
    }
}

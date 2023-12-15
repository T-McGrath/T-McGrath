using System;
using System.IO;

namespace WordSearch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Ask the user for the file path
            Console.WriteLine("Enter the path of the file to be read: ");
            string userFilePath = Console.ReadLine();//.ToLower(); THIS FAILED THE BOS TESTS!
            //2. Ask the user for the search string
            Console.WriteLine("Enter a word you'd like to find in the text: ");
            string userTargetWord = Console.ReadLine();

            Console.WriteLine("Should the search be case-sensitive? (Y/N)");
            string caseSensitiveSelection = Console.ReadLine().ToUpper();
            bool isCaseSensitive = false;
            // I wanted to try a do while loop. Don't know if this was really an efficient
            // way of doing things.
            do
            {
                if (caseSensitiveSelection == "Y")
                {
                    isCaseSensitive = true;
                }
                else if (caseSensitiveSelection == "N")
                {
                    isCaseSensitive = false;
                }
                else
                {
                    Console.WriteLine("Input not recognized. Please answer the following question with Y or N.\nShould the search be case-sensitive?");
                    caseSensitiveSelection = Console.ReadLine().ToUpper();
                }
            } while (caseSensitiveSelection != "Y" && caseSensitiveSelection != "N");

            try
            {
                Console.WriteLine();
                //3. Open the file
                using (StreamReader fileInput = new StreamReader(userFilePath))
                {
                    int lineCount = 1;
                    //4. Loop through each line in the file
                    while (!fileInput.EndOfStream)
                    {
                        string curLineOfText = fileInput.ReadLine();
                        //5. If the line contains the search string, print it out along with its line number
                        if (isCaseSensitive)
                        {
                            if (curLineOfText.Contains(userTargetWord))
                            {
                                Console.WriteLine($"{lineCount}: {curLineOfText}");
                            }
                        }
                        else
                        {
                            if (curLineOfText.ToLower().Contains(userTargetWord.ToLower()))
                            {
                                Console.WriteLine($"{lineCount}: {curLineOfText}");
                            }
                        }
                        lineCount++;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file path you typed does not exist.");
            }
        }
    }
}

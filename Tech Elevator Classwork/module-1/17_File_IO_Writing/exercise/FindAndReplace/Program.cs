using System;
using System.IO;

namespace FindAndReplace
{
    public class Program
    {
		public static void Main(string[] args)
		{
            //string curDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine("Type a target word for which you'd like to search. This WILL be a case-sensitive search.");
            string userTargetWord = Console.ReadLine();
            Console.WriteLine("Type a replacement word for your target word.");
            string userReplacementWord = Console.ReadLine();
            Console.WriteLine("Type the path of the source file. That is, the file we will look through\n" +
                "for the target word. Please include the file extension.");
            string sourceFilePath = Console.ReadLine();
            //string sourceFullPath = Path.Combine(curDirectory, sourceFileName);
            Console.WriteLine("Type the path of the destination file. That is, the file that will\n" +
                "contain all text from the source with the target word replaced with\n" +
                "the replacement word. Please include the file extension.");
            string destFilePath = Console.ReadLine();
            //string destFullPath = Path.Combine(curDirectory, destFileName);
            try
            {
                using (StreamReader reader = new StreamReader(sourceFilePath))
                {
                    // ReadToEnd() feels like cheating, but maybe I was just being resourceful? I'll look at it that way.
                    string textAfterReplacement = reader.ReadToEnd().Replace(userTargetWord, userReplacementWord);
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(destFilePath, false))
                        {
                            writer.Write(textAfterReplacement);
                        }
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine("The destination file path you typed is incorrect or non-existent.");
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The source path you typed is incorrect or non-existent.");
            }
        }
    }
}

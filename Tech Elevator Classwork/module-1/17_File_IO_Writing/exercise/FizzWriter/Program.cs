using System;
using System.IO;

namespace FizzWriter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Type the path and file name of the destination file.");
            string destPath = Console.ReadLine();

            try
            {
                using (StreamWriter writer = new StreamWriter(destPath))
                {
                    for (int i = 1; i <= 300; i++)
                    {
                        if (i % 15 == 0)
                        {
                            writer.WriteLine("FizzBuzz");
                        }
                        else if (i % 5 == 0)
                        {
                            writer.WriteLine("Buzz");
                        }
                        else if (i % 3 == 0)
                        {
                            writer.WriteLine("Fizz");
                        }
                        else
                        {
                            writer.WriteLine(i);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The path you typed is incorrect. Please type more carefully next time.");
            }

        }
    }
}

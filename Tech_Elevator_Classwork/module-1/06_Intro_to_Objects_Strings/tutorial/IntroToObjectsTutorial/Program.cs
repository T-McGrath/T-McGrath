using System;

namespace IntroToObjectsTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            // ***********  Step 1: Use the *new* operator to create strings on the Heap  *************
            //char[] helloChars = new char[] { 'h', 'e', 'l', 'l', 'o', '!' };
            //string greeting = new string(helloChars);
            //Console.WriteLine("Greeting: " + greeting);

            //string greetingLiteral = greeting;
            //Console.WriteLine("New greeting: " + greetingLiteral);



            DateTime dateTimeRightNow = DateTime.Now;
            Console.WriteLine("Default format current date and time: " + dateTimeRightNow);
            Console.WriteLine("Short date: " + dateTimeRightNow.ToShortDateString());
            Console.WriteLine("Long date: " + dateTimeRightNow.ToLongDateString());
            Console.WriteLine("Short time: " + dateTimeRightNow.ToShortTimeString());
            Console.WriteLine("Long time: " + dateTimeRightNow.ToLongTimeString());
            Console.WriteLine("Everything short by concatenating: " + dateTimeRightNow.ToShortDateString() + " "+ dateTimeRightNow.ToShortTimeString());
            Console.WriteLine("Everything long by concatenating: " + dateTimeRightNow.ToLongDateString() + " " + dateTimeRightNow.ToLongTimeString());
        }
    }
}

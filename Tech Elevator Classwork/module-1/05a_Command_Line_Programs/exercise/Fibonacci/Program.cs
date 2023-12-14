using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int previousNum = 1;
            int extraPreviousNum = 0;
            int userNum;
            while(true)
            {
                try
                {
                    Console.WriteLine("Hello, Sir Benjamin. Please type an integer.");
                    userNum = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("You did not type an integer; please try again.");
                }
            }
            Console.Write("0, 1");
            int fibNumber = previousNum + extraPreviousNum;
            while (fibNumber <= userNum)
            {
                ;
                if (fibNumber < userNum)
                {
                    Console.Write(", " + fibNumber);
                }
                else if (fibNumber == userNum)
                {
                    Console.Write(", " + fibNumber);
                }
                //else
                //{
                //    break;
                //}
                extraPreviousNum = previousNum;
                previousNum = fibNumber;
                fibNumber = previousNum + extraPreviousNum;
            }
            
        }
    }
}

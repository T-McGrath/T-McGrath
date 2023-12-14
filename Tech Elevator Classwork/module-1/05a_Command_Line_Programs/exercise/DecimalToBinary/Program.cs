using System;
using System.Security.Cryptography.X509Certificates;

namespace DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            // I used to be a math teacher...hope you don't mind logarithms!
            // Also, I wrote the whole program and then realized that the user was allowed to type 
            // MULTIPLE integers. Sooo, I just put all my original code into a method to simplify things a bit. 
            // That allowed me to focus on dealing with the multiple integers part and call the method as many times as needed.
            Console.WriteLine("Hey Ben! Please, enter at least one whole number (non-negative integer). Add a space between each number.");
            string userNum = Console.ReadLine();
            string[] baseTenNumAsStringArray = userNum.Split(' ');
            int[] baseTenNumArray = new int[baseTenNumAsStringArray.Length];

            try
            {
                for (int i = 0; i < baseTenNumArray.Length; i++)
                {
                    baseTenNumArray[i] = int.Parse(baseTenNumAsStringArray[i]);
                    Console.WriteLine("The binary version of " + baseTenNumAsStringArray[i] + " is " + DecimalToBinary(baseTenNumArray[i]) + ".");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Please run again and enter only WHOLE NUMBERS (numeric) separated by spaces..." +
                    "no negatives, decimals, letters or anything else.");
            }
        }

        public static string DecimalToBinary(int numToConvert)
        {
            string binaryNum = "";

            if (numToConvert == 0)
            {
                return "0";
            }
            else
            {
                binaryNum += "1";
                int highestTwoPower = (int)Math.Log2(numToConvert);
                int twoToPowerValue = (int)Math.Pow(2, highestTwoPower);
                numToConvert -= twoToPowerValue;

                for (int i = highestTwoPower - 1; i >= 0; i--)
                {
                    twoToPowerValue = (int)Math.Pow(2, i);
                    if (numToConvert - twoToPowerValue >= 0)
                    {
                        binaryNum += "1";
                        numToConvert -= twoToPowerValue;
                    }
                    else
                    {
                        binaryNum += "0";
                    }
                }
            }
            return binaryNum;
        }
    }
}

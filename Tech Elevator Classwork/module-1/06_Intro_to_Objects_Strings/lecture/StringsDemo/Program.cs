using System;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Ada Lovelace";

            // Strings are actually arrays of characters (char).
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e

            Console.WriteLine("First and Last Character:");
            Console.WriteLine(name[0]);
            Console.WriteLine(name[name.Length - 1]);
            Console.WriteLine();


            // 2. How do we write code that prints out the first three characters
            // Output: Ada

            Console.WriteLine("First 3 characters: ");
            Console.WriteLine(name.Substring(0, 3));
            Console.WriteLine();

            // 3. Now print out the first three and the last three characters
            // Output: Adaace

            Console.WriteLine("Last 3 characters: ");
            Console.WriteLine(name.Substring(0, 3) + name.Substring(name.Length - 3));
            Console.WriteLine();
            // 4. What about the last word?
            // Output: Lovelace

            Console.WriteLine("Last Word: ");
            //Console.WriteLine(name.Substring(name.IndexOf(" ") + 1));
            string[] stringArray = name.Split(' ');
            Console.WriteLine(stringArray[stringArray.Length - 1]);
            Console.WriteLine();
            // 5. Does the string contain inside of it "Love"?
            // Output: true

            Console.WriteLine("Contains \"Love\"");
            Console.WriteLine(name.Contains("Love")); // or ;name.IndexOf("Love") != -1)
            Console.WriteLine();

            // 6. Where does the string "lace" show up in name?
            // Output: 8

            Console.WriteLine("Index of \"lace\": ");
            Console.WriteLine(name.IndexOf("lace")); 
            Console.WriteLine();

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3

            Console.WriteLine("Number of \"a's\": ");
            int countOfA = 0;
            for(int i = 0; i < name.Length; i++)
            {
                if (name[i] == 'a' || name[i] == 'A')
                {
                    countOfA++;
                }
            }
            Console.WriteLine(countOfA);
            Console.WriteLine();

            // 8. Replace "Ada" with "Ada, Countess of Lovelace"

            Console.WriteLine(name.Replace(" ", ", Countess of "));
            Console.WriteLine();

            // 9. Set name equal to null.

            Console.WriteLine("name is now set to null.");
            name = null;
            Console.WriteLine();

            // 10. If name is equal to null or "", print out "All Done".

            if(name == null || name == "")
            {
                Console.WriteLine("All done!");
            }
            else
            {
                Console.WriteLine("Didn't follow directions!!!!!!!!!!");
            }
        }
    }
}
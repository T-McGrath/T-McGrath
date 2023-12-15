using System;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Ada Lovelace";
            int length = name.Length;
            string demo = "a substring is a piece";
            int demoLength = demo.Length;
            string littleDemo = demo.Substring(17);
            string littleDemoWithTwoInputs = demo.Substring(2, 9);
            int placeholder = 0;

            // Strings are actually arrays of characters (char).
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e

             Console.WriteLine("First and Last Character: ");
            Console.WriteLine(name[0]);
            Console.WriteLine(name[name.Length - 1]);
            Console.WriteLine();
            // 2. How do we write code that prints out the first three characters
            // Output: Ada

            Console.WriteLine("First 3 characters: ");
            Console.WriteLine(name.Substring(0, 3));
            // 3. Now print out the first three and the last three characters
            // Output: Ada ace

            Console.WriteLine("Last 3 characters: ");
            Console.WriteLine($"{name.Substring(0, 3)} {name.Substring(name.Length - 3)}");

            // 4. What about the last word?
            // Output: Lovelace

            string[] wholeName = name.Split(' ');
            string firstName = wholeName[0];
            string lastName = wholeName[wholeName.Length - 1];
             
            

            Console.WriteLine($"Last Word: using substring: {name.Substring(4)} or using string.Split and last element: {lastName}.");

            // 5. Does the string contain inside of it "Love"?
            // Output: true

            Console.WriteLine("Contains \"Love\"");
            Console.WriteLine("Output: " + name.Contains("Love", StringComparison.CurrentCultureIgnoreCase));
            // 6. Where does the string "lace" show up in name?
            // Output: 8

            // Console.WriteLine("Index of \"lace\": ");
            Console.WriteLine("Output: " + name.IndexOf("lace"));
            // 7. How many 'a's OR 'A's are in name?
            // Output: 3
            name = name.ToUpper(); //ADA LOVELACE
            int totalA = 0;
            for(int i = 0; i<name.Length; i++)
            {
               if( name[i] == 'A')
                {
                    totalA++;
                }
            }
            Console.WriteLine("Number of \"a's\": " + totalA);
            Console.WriteLine($"Number of \"a's\" :{totalA}");

            // 8. Replace "Ada" with "Ada, Countess of Lovelace"
            string nameWithReplacements = name.Replace("ADA", "Ada, Countess of Lovelace");
            // Console.WriteLine(name);
            Console.WriteLine(nameWithReplacements);
            // 9. Set name equal to null.
            name = null;
            // 10. If name is equal to null or "", print out "All Done".
            if(name == null)
            {
                Console.WriteLine("All Done");
            }
        }
    }
}

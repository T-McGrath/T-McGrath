using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsPart1Lecture
{
    public class CollectionsPart1Lecture
	{
        static void Main(string[] args)
        {
            Console.WriteLine("####################");
            Console.WriteLine("       LISTS");
            Console.WriteLine("####################");
            //List<string> declaredList;
            //declaredList= new List<string>();
            List<string> petNames = new List<string>();
            petNames.Add("Daisy");
            petNames.Add("Piper");
            List<string> jennysPets = new List<string>() { "Cookie", "Coda" };
            petNames.AddRange(jennysPets);
            List<string> lorisPets = new List<string>()
            {
                "Foxy",
                "Lily",
                "Luna",
                "Snowflake"
            };
            petNames.AddRange(lorisPets);
            petNames.Add("Potato");
            petNames.Add("Spud");
            lorisPets.Add("Fruity the fruit fly");

            Console.WriteLine("####################");
            Console.WriteLine("Lists are ordered");
            Console.WriteLine("####################");
            Console.WriteLine(petNames);
            Console.WriteLine($"The number of pets in this list is: {petNames.Count}");
            //for(int i =0; i<petNames.Count;i+=2) <- can iterate by two to show every other element
            PrintListToConsole(petNames);

            Console.WriteLine("####################");
            Console.WriteLine("Lists allow duplicates");
            Console.WriteLine("####################");
            petNames.Add("Foxy");

            Console.WriteLine("####################");
            Console.WriteLine("Lists allow elements to be inserted in the middle");
            Console.WriteLine("####################");
            petNames.Insert(5, "Fruity");
            PrintListToConsole(petNames);

            Console.WriteLine("####################");
            Console.WriteLine("Lists allow elements to be removed by index");
            Console.WriteLine("####################");
            petNames.Remove("Foxy");
            Console.WriteLine("Testing whether the first Foxy is the only one removed:");
            PrintListToConsole(petNames);

            petNames.Remove("Fruity");
            petNames.RemoveAt(petNames.Count - 1);
            bool isRemoved = petNames.Remove("Oscar");
            Console.WriteLine(isRemoved ? "We removed 'Oscar' from the list" : "We did not remove 'Oscar' from the list");

            Console.WriteLine("####################");
            Console.WriteLine("Find out if something is already in the List");
            Console.WriteLine("####################");
            bool conatainsDaisy = petNames.Contains("Daisy");
            Console.WriteLine(conatainsDaisy ? "Does has Daisy" : "Does not");

            Console.WriteLine("####################");
            Console.WriteLine("Find index of item in List");
            Console.WriteLine("####################");
            int indexOfLuna = petNames.IndexOf("Luna");
            Console.WriteLine($"Index of Luna: {indexOfLuna}");

            Console.WriteLine("####################");
            Console.WriteLine("Lists can be turned into an array");
            Console.WriteLine("####################");
            string[] petArray = petNames.ToArray();
            Console.WriteLine();
            Console.WriteLine("####################");
            Console.WriteLine("Lists can be sorted");
            Console.WriteLine("####################");
            petNames.Sort();
            petNames.Reverse();

            Console.WriteLine("####################");
            Console.WriteLine("Lists can be reversed too");
            Console.WriteLine("####################");


            Console.WriteLine("####################");
            Console.WriteLine("       FOREACH");
            Console.WriteLine("####################");
            Console.WriteLine();
            //foreach(string hedgehog in petNames)
            //foreach(string petName in petNames)
            //{

            //}
            //prints out only the pets that start with 'L'
            //you can't modify the collection itself during iteration in a foreach loop
            foreach(string element in petNames)
            {
                if (element.StartsWith('L'))
                {
                    Console.WriteLine(element);
                }
            }


        }

        private static void PrintListToConsole(List<string> petNames)
        {
            for (int i = 0; i < petNames.Count; i++)
            {
                Console.WriteLine(petNames[i]);
            }
        }
    }
}

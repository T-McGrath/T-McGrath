using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsPart2Lecture
{
    public class CollectionsPart2Lecture
	{
		static void Main(string[] args)
		{
			Console.WriteLine("####################");
			Console.WriteLine("       DICTIONARIES");
			Console.WriteLine("####################");
			Console.WriteLine();

			Dictionary<string, List<string>> classPetNames = new Dictionary<string, List<string>>()
			{
				{"Chris", new List<string> {"Daisy", "Bingo"} },
				{"Lusia", new List<string> {"Potato", "Spud"}},
				{"Lori", new List<string> {"Foxy", "Lily", "Luna", "Snowflake"} },
				{"ChrisM", new List<string> {"Outlaw"} }
			};
			classPetNames["Preston"] = new List<string> { "Cleo", "Luna", "Regal", "Rainy", "Simba" };
			List<string> chrissPets = classPetNames["Chris"];
            Console.Write("The pet owned by Chris is: ");
            foreach (string element in chrissPets)
			{
				Console.Write(element+ " ");
				
            }
			Console.WriteLine();
			Console.WriteLine("Moving on....");
			List<string> anotherLoriPets = new List<string> { "differentPet1", "differentPet2" };

			classPetNames["Lori"] = anotherLoriPets;

			foreach(KeyValuePair<string, List<string>> kvp in classPetNames)
			{
				Console.Write($"The pets who belong to  {kvp.Key} are ");
				foreach(string element in kvp.Value)
				{
					Console.Write(element+ " ");
				}
				Console.WriteLine();
			}

            //that was the example given in class but here is from the curriculum team
            Dictionary<string, string> nameToZip = new Dictionary<string, string>();

            // Adding an item to a Dictionary
            nameToZip["David"] = "44120";
            nameToZip["Dan"] = "44124";
            nameToZip["Elizabeth"] = "44012";

            // Retrieving an item from a Dictionary
            Console.WriteLine("David lives in " + nameToZip["David"]);
            Console.WriteLine("Dan lives in " + nameToZip["Dan"]);
            Console.WriteLine("Elizabeth lives in " + nameToZip["Elizabeth"]);
            Console.WriteLine();

			//you can retrieve all of the keys of any dictionary into a collection. You use the .Keys property given by microsoft.
			List<string> keys = nameToZip.Keys.ToList();
            
			if (nameToZip.ContainsKey("David"))
            {
                Console.WriteLine("David exists");
            }
            Console.WriteLine();

            Console.WriteLine("set 12345 for key David");
            //nameToZip.Add("David", "12345"); // Uncomment this to show exception. The key "David" already exists, so using Add() with a key that already exists will throw an ArgumentException

            nameToZip["David"] = "12345"; // to overwrite a value for an existing key, use the same square bracket syntax

			foreach(KeyValuePair<string, string> kvp in nameToZip)
			{
                Console.WriteLine(kvp.Key + " lives in " + kvp.Value);
            }
            Console.WriteLine();

            // Remove an element from the Dictionary
            nameToZip.Remove("David");
            Console.WriteLine("removed David");
            Console.WriteLine();

            // loop through again to show David was removed
            foreach (KeyValuePair<string, string> nameZip in nameToZip)
            {
                Console.WriteLine(nameZip.Key + " lives in " + nameZip.Value);
            }
            Console.WriteLine();
        }
    }
}

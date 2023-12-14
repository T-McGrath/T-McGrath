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
				{"Chris", new List<string>() {"Daisy", "Bingo"} },
				{"Lusia", new List<string> {"Potato", "Spud" } },
				{"Lori", new List<string> {"Foxy", "Lily", "Luna", "Snowflake" } },
				{"ChrisM", new List<string> {"Outlaw" } }
			};
			classPetNames["Preston"] = new List<string> { "Cleo", "Luna", "Regal", "Rainy", "Simba" };
			List<string> chrisPets = classPetNames["Chris"];
            Console.WriteLine($"The pet(s) owned by Chris is ");
            foreach (string pet in chrisPets)
			{
				Console.Write($"{pet} ");
			}
			Console.WriteLine();
			Console.WriteLine();
			List<string> anotherLoriPets = new List<string> { "pet1", "pet2" };
			classPetNames["Lori"] = anotherLoriPets;

			foreach(KeyValuePair<string, List<string>> dictItem in classPetNames)
			{
				Console.Write($"The pet(s) who belong to {dictItem.Key} is(are) ");
				foreach(string name in dictItem.Value)
				{
					Console.Write(name + " ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();

			// #################################################
			// Another example:
			Dictionary<string, string> nameToZip = new Dictionary<string, string>();

			// Add stuff to the dictionary.
			nameToZip["David"] = "44120";
			nameToZip["Dan"] = "44124";
			nameToZip["Elizabeth"] = "44012";

			// Accessing/using the things in the dictionary.
			Console.WriteLine("David lives in " + nameToZip["David"]);
			Console.WriteLine();


			// Can get all the keys from the dictionary and put them into a different collection, like a list.
			List<string> keys = nameToZip.Keys.ToList();


			foreach(KeyValuePair<string, string> kvp in nameToZip)
			{
				Console.WriteLine(kvp.Key + " lives in zip code " + kvp.Value);
			}
			Console.WriteLine();

			nameToZip["David"] = "12345";
			Console.WriteLine("Changed David's zip.");
            foreach (KeyValuePair<string, string> kvp in nameToZip)
            {
                Console.WriteLine(kvp.Key + " lives in zip code " + kvp.Value);
            }
            Console.WriteLine();

            nameToZip.Remove("David");
			Console.WriteLine("Removed David...poor David");
            foreach (KeyValuePair<string, string> kvp in nameToZip)
            {
                Console.WriteLine(kvp.Key + " lives in zip code " + kvp.Value);
            }
            Console.WriteLine();
        }
	}
}

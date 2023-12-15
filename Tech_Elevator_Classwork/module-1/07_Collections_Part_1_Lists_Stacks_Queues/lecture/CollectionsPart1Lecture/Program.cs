using System;
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

			Console.WriteLine("####################");
			Console.WriteLine("Lists are ordered");
			Console.WriteLine("####################");

			Console.WriteLine($"The number of pets in this list is: {petNames.Count}\nThe names are...");
			PrintList(petNames);


			Console.WriteLine("####################");
			Console.WriteLine("Lists allow duplicates");
			Console.WriteLine("####################");

			petNames.Add("Foxy");


			Console.WriteLine("####################");
			Console.WriteLine("Lists allow elements to be inserted in the middle");
			Console.WriteLine("####################");

			petNames.Insert(5, "Fruity");
			PrintList(petNames);


			Console.WriteLine("####################");
			Console.WriteLine("Lists allow elements to be removed by index");
			Console.WriteLine("####################");

			petNames.Remove("Fruity");
			petNames.RemoveAt(petNames.Count - 1);

			Console.WriteLine("####################");
			Console.WriteLine("Find out if something is already in the List");
			Console.WriteLine("####################");
			bool containsCoda = petNames.Contains("Coda");

			Console.WriteLine(containsCoda ? "'Coda' is in the list." : "'Coda' is not in the list.");
			Console.WriteLine();


			Console.WriteLine("####################");
			Console.WriteLine("Find index of item in List");
			Console.WriteLine("####################");

			int indexOfFoxy = petNames.IndexOf("Foxy");
			Console.WriteLine($"The index of 'Foxy' is {indexOfFoxy}.");

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be turned into an array");
			Console.WriteLine("####################");

			string[] petNamesArray = petNames.ToArray();

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be sorted");
			Console.WriteLine("####################");

			petNames.Sort();
			Console.WriteLine("The petNames list is now sorted alphabetically:");
			PrintList(petNames);

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be reversed too");
			Console.WriteLine("####################");

			petNames.Reverse();
			Console.WriteLine("The petNames list is now sorted in REVERSE alphabetical order.");
			Console.WriteLine();

			Console.WriteLine("####################");
			Console.WriteLine("       FOREACH");
			Console.WriteLine("####################");
			
			foreach(string name in petNames)
			{
				if (name.StartsWith('L'))
				{
                    Console.WriteLine(name);
                }
				
			}
		}

		public static void PrintList(List<string> list)
		{
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine();
        }
	}
}

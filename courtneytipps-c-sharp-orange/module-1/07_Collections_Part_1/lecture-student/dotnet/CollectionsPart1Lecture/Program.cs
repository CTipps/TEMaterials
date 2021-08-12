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
			petNames.Add("Persephone");
			petNames.Add("Otis");
			petNames.Add("Clover");
			petNames.Add("Leeloo");

			Console.WriteLine("####################");
			Console.WriteLine("Lists are ordered");
			Console.WriteLine("####################");

			foreach (string pet in petNames)
            {
                Console.WriteLine(pet);
            }

			Console.WriteLine("####################");
			Console.WriteLine("Lists allow duplicates");
			Console.WriteLine("####################");
			
			petNames.Add("Leeloo");
			foreach (string pet in petNames)
			{
				Console.WriteLine(pet);
			}

			Console.WriteLine("####################");
			Console.WriteLine("Lists allow elements to be inserted in the middle");
			Console.WriteLine("####################");

			petNames.Insert(1, "Charcoal");
			foreach (string pet in petNames)
			{
				Console.WriteLine(pet);
			}

			Console.WriteLine("####################");
			Console.WriteLine("Lists allow elements to be removed by index");
			Console.WriteLine("####################");

			petNames.RemoveAt(petNames.Count - 1);
			foreach (string pet in petNames)
			{
				Console.WriteLine(pet);
			}

			Console.WriteLine("####################");
			Console.WriteLine("Find out if something is already in the List");
			Console.WriteLine("####################");

			Console.WriteLine("Contains Otis? " + petNames.Contains("Otis"));

			Console.WriteLine("####################");
			Console.WriteLine("Find index of item in List");
			Console.WriteLine("####################");

			Console.WriteLine("Index of Persephone is " + petNames.IndexOf("Persephone"));

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be turned into an array");
			Console.WriteLine("####################");

			string[] result = petNames.ToArray();
			foreach (string pet in result)
			{
				Console.WriteLine(pet);
			}

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be sorted");
			Console.WriteLine("####################");

			petNames.Sort();
			foreach (string pet in petNames)
			{
				Console.WriteLine(pet);
			}

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be reversed too");
			Console.WriteLine("####################");

			petNames.Reverse();
			foreach (string pet in petNames)
			{
				Console.WriteLine(pet);
			}

			Console.WriteLine("####################");
			Console.WriteLine("       FOREACH");
			Console.WriteLine("####################");
			Console.WriteLine();


		}
	}
}

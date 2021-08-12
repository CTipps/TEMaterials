using System;
using System.Collections.Generic;

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

            Dictionary<string, int> petAges = new Dictionary<string, int>();

            petAges["persephone"] = 1;
            petAges["otis"] = 3;
            petAges["clover"] = 2;
            petAges["leeloo"] = 7;

            foreach (string name in petAges.Keys)
            {
                Console.WriteLine(name);
            }

            int sum = 0;
            foreach (int value in petAges.Values)
            {
                sum += value;
            }
            double average = (double)sum / petAges.Count;
            Console.WriteLine("Average age is: " + average);

            while (true)
            {
                foreach (KeyValuePair<string, int> kvp in petAges)
                {
                    Console.WriteLine(kvp.Key + "is age: " + kvp.Value);
                }
                Console.Write("Please enter a pet name: ");
                string userInput = Console.ReadLine();
                string userLower = userInput.ToLower();
                Console.Write("Please enter a pet age, 0 to leave unchanged: ");
                string petAge = Console.ReadLine();
                int age = int.Parse(petAge);

                if (!petAges.ContainsKey(userLower))
                {
                    Console.WriteLine("Key not found, please try again.");
                }
                else
                {
                    Console.WriteLine(userInput + " is age " + petAges[userLower]);

                    if (age != 0)
                    {
                        petAges[userLower] = age;
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfo
{
    public class UserInterface
    {
        private List<Pet> pets = new List<Pet>();
        public void UserMenu()
        {
            bool done = false;

            while (!done)
            {
                DisplayMenu();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddAPet();
                        break;
                    case "2":
                        DeletePet();
                        break;
                    case "3":
                        ListPets();
                        break;
                    case "q":
                    case "Q":
                        done = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please enter a valid choice");
                        break;
                }
            }
        }
        private void DisplayMenu()
        {
            Console.WriteLine("Please make a selection:");
            Console.WriteLine("1 - Add a pet");
            Console.WriteLine("2 - Delete a pet");
            Console.WriteLine("3 - List Pets");
            Console.WriteLine("Q - Quit the program");
        }
        private void AddAPet()
        {
            Console.Write("Please enter a pet Id number: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Please enter a pet name: ");
            string name = Console.ReadLine();

            Console.Write("Please enter a pet type (cat, dog, etc.): ");
            string type = Console.ReadLine();

            Console.Write("Please enter pet breed: (German Shephard, DSH, etc.) ");
            string breed = Console.ReadLine();

            Pet pet = new Pet(id, name, type, breed);

            pets.Add(pet);
        }
        private void ListPets()
        {
            foreach (Pet pet in pets)
            {
                Console.WriteLine(pet);
            }
        }
        private void DeletePet()
        {
            Console.WriteLine("Please enter a pet Id number: ");
            int id = int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < pets.Count; i++)
            {
                if (pets[i].Id == id)
                {
                    break;
                }
            }
            if (i < pets.Count)
            {
                pets.RemoveAt(i);
            }
            else
            {
                Console.WriteLine("Item not found");
            }
        }
    }
}

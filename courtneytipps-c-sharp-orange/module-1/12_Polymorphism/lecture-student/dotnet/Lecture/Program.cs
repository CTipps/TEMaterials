﻿using Lecture.Farming;
using System;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // OLD MACDONALD
            //
            IMakeSound[] animals = new IMakeSound[] { new Cow(), new Chicken(), new Dog(), new Tractor() };

            foreach (FarmAnimal animal in animals)
            {
                Console.WriteLine("Old MacDonald had a farm, ee ay ee ay oh!");
                Console.WriteLine("And on his farm he had a " + animal.Name + ", ee ay ee ay oh!");
                Console.WriteLine("With a " + animal.Sound + " " + animal.Sound + " here");
                Console.WriteLine("And a " + animal.Sound + " " + animal.Sound + " there");
                Console.WriteLine("Here a " + animal.Sound + " there a " + animal.Sound + " everywhere a " + animal.Sound + " " + animal.Sound);
                Console.WriteLine("BTW: the age of the thing is " + animal.GetAge());
                Console.WriteLine();
            }
            Console.WriteLine("Old MacDonald had a farm, ee ay ee ay oh!");

        }
    }
}
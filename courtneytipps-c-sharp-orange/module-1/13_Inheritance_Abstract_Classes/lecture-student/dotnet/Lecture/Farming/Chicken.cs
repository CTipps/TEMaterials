using System;

namespace Lecture.Farming
{
    public class Chicken : FarmAnimal
    {
        public override string Name { get; } = "Chicken";
        public Chicken() : base("cluck")
        {
        }

        public void LayEgg()
        {
            Console.WriteLine("Chicken laid an egg!");
        }
    }
}

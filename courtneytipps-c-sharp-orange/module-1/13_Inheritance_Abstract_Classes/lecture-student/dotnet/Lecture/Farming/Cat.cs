using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    class Cat : FarmAnimal, ISellable
    {
        public decimal Price { get; }
        public override string Name { get; } = "Cat";
        public Cat() : base("meow")
        {
            Price = 5.00M;
        }

    }
}

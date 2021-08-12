using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    class Dog : FarmAnimal
    {
        public override int GetAge()
        {
            return 3;
        }
        public Dog() : base("Dog", "Woof")
        {
        }
    }
}

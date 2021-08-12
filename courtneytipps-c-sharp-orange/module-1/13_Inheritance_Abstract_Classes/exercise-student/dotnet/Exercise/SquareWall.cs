using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    class SquareWall : RectangleWall
    {
        public int SideLength { get; }
        public SquareWall(string name, string color, int sideLength) : base(name, color, sideLength, sideLength)
        {
            SideLength = sideLength;
        }
        public override string ToString()
        {
            return $"{Name} ({SideLength}x{SideLength}) square";
        }

    }

}

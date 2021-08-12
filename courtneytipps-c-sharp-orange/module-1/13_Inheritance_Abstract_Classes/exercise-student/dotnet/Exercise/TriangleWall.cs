using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    class TriangleWall : Wall
    {
        public int Base { get; }
        public int Height { get; }

        public TriangleWall(string name, string color, int  triangleBase, int height) : base (name, color)
        {
            this.Base = triangleBase;
            Height = height;
        }

        public override int GetArea()
        {
            return (Base * Height) / 2;
        }
        public override string ToString()
        {
            return $"{Name} ({Base}x{Height}) triangle";
        }
    }
}

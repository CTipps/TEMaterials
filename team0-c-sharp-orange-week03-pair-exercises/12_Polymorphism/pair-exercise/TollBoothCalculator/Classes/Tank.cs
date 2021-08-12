using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
    class Tank : IVehicle
    {
        public string Type { get; } = "Tank";
        public double CalculateToll(int distance)
        {
            return 0;
        }
    }
}

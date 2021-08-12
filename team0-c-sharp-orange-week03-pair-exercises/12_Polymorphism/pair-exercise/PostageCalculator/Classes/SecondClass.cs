using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class SecondClass : IDeliveryDriver
    {
        public string Name { get; } = "Postal Service (2nd Class) ";

        public double CalculateRate(int distance, double weight)
        {
            if (weight <= 2)
            {
                return 0.0035 * distance;
            }
            else if (weight <= 8)
            {
                return 0.0040 * distance;
            }
            else if (weight <= 15)
            {
                return 0.0047 * distance;
            }
            else if (weight <= 48)
            {
                return 0.0195 * distance;
            }
            else if (weight <= 128)
            {
                return 0.0450 * distance;
            }
            else
            {
                return 0.050 * distance;
            }
        }
    }
}

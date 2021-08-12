using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class ThirdClass : IDeliveryDriver
    {
        public string Name { get; } = "Postal Service (3rd Class) ";

        public double CalculateRate(int distance, double weight)
        {


            if (weight <= 2)
            {
                return 0.0020 * distance;
            }
            else if (weight <= 8)
            {
                return 0.0022 * distance;
            }
            else if (weight <= 15)
            {
                return 0.0024 * distance;
            }
            else if (weight <= 48)
            {
                return 0.0150 * distance;
            }
            else if (weight <= 128)
            {
                return 0.0160 * distance;
            }
            else
            {
                return 0.0170 * distance;
            }
        }
    }
}

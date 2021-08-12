using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class FirstClass : IDeliveryDriver
    {
        public string Name { get; } = "Postal Service (1st Class) ";

        public double CalculateRate(int distance, double weight)
        {
            if (weight <= 2)
            {
                return 0.035 * distance;
            }
            else if(weight <= 8)
            {
                return 0.040 * distance;
            }
            else if (weight <= 15)
            {
                return 0.047 * distance;
            }
            else if (weight <= 48)
            {
                return 0.195 * distance;
            }
            else if (weight <= 128)
            {
                return 0.450 * distance;
            }
            else
            {
                return 0.50 * distance;
            }
        }
    }
}

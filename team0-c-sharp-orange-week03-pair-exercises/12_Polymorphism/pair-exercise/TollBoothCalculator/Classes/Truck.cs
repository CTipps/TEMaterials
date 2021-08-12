using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
    class Truck : IVehicle
    {
        public string Type
        {
            get
            {
                if (NumberOfAxles == 4)
                {
                    return "Truck (4 axles)";
                }
                else if (NumberOfAxles == 6)
                {
                    return "Truck (6 axles)";
                }
                else
                {
                    return "Truck (8+ axles)";
                }
            }
        }
        public int NumberOfAxles { get; }

        public Truck(int numberOfAxles)
        {
            NumberOfAxles = numberOfAxles;
        }

        public double CalculateToll(int distance)
        {
            if (NumberOfAxles == 4)
            {
                return .04 * distance;
            } else if (NumberOfAxles == 6)
            {
                return .045 * distance;
            } else
            {
                return .048 * distance;
            }
        }
    }
}

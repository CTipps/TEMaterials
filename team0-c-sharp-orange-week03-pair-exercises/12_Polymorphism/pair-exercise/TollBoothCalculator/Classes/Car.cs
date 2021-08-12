using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
   public class Car : IVehicle
    {
        public string Type { get 
            { if (HasTrailer)
                {
                    return "Car (with Trailer)";
                } else
                {
                    return "Car";
                }
            } 
        }
        public bool HasTrailer { get; }


        public Car(bool hasTrailer)
        {
            HasTrailer = hasTrailer;
        }

        public double CalculateToll(int distance)
        {
            if (HasTrailer)
            {
                return (.02 * distance) + 1;
            }
            else
            {
                return .02 * distance;
            }
        }
    }
}

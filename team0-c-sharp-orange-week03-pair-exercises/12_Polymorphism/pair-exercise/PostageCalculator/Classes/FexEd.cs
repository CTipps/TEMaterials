using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class FexEd : IDeliveryDriver
    {
        public string Name { get; } = "FexEd";
        public double CalculateRate(int distance, double weight)
        {
            double rate = 20.00;
            if (distance > 500)
            {
                rate += 5.00;
            }

            if (weight > 48)
            {
                rate += 3.00;
            }

            return rate;
        }


    }
}

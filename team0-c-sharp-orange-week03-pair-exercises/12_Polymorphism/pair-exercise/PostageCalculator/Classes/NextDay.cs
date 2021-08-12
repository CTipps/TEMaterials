using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class NextDay : IDeliveryDriver
    {
        public string Name { get; } = "SPU (Next Day) ";

        public double CalculateRate(int distance, double weight)
        {
            return ((weight * 0.075) * distance)/16;
        }
    }
}

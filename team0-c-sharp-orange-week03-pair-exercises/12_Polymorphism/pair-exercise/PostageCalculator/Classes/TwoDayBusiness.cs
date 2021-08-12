using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class TwoDayBusiness : IDeliveryDriver
    {
        public string Name { get; } = "SPU (2-Day Business) ";

        public double CalculateRate(int distance, double weight)
        {
            return ((weight * 0.050) * distance)/16;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class FourDayGround : IDeliveryDriver
    {
        public string Name { get; } = "SPU (4-Day Ground) ";

        public double CalculateRate(int distance, double weight)
        {
            return ((weight * 0.0050) * distance)/16;
        }
    }
}

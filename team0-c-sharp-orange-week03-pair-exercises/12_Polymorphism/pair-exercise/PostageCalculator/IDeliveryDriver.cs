using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator
{
    interface IDeliveryDriver
    {
        string Name { get; }
        double CalculateRate(int distance, double weight);
        
    }
}

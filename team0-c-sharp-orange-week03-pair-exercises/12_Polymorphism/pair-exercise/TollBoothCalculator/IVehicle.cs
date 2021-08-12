using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator
{
    interface IVehicle
    {
        string Type { get; }
        double CalculateToll(int distance);
    }
}

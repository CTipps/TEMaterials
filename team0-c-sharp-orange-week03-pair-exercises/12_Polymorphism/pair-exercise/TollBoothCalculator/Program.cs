
﻿using System;
using System.Collections.Generic;
using TollBoothCalculator.Classes;

namespace TollBoothCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            IVehicle[] vehicles = new IVehicle[] { new Car(false), new Car(true), new Truck(4), new Truck(6), new Truck(8), new Tank() };
            List<IVehicle> vehiclesPassed = new List<IVehicle>();
            vehiclesPassed.AddRange(vehicles);
            Random rand = new Random();
            
            int totalMiles = 0;
            double totalRevenue = 0;
            //                v Used to format spacing, {index, spacing in pixels} \n = new line
            Console.WriteLine("{0,-20} {1,19} {2,13}\n\n", "Vehicle Type", "Distance Travelled", "Toll Amount");
            foreach (IVehicle vehicle in vehiclesPassed)
            {
                int distanceTravelled = rand.Next(10, 241);
                double toll = vehicle.CalculateToll(distanceTravelled);
                Console.WriteLine("{0,-20} {1,11} {2,18}\n", vehicle.Type, distanceTravelled, toll.ToString("C"));
                totalMiles += distanceTravelled;
                totalRevenue += toll;
            }
                Console.WriteLine("Total Miles Traveled: " + totalMiles);
                Console.WriteLine("Total Tollbooth Revenue: " + totalRevenue.ToString("C"));
        
        
        }
    }
}

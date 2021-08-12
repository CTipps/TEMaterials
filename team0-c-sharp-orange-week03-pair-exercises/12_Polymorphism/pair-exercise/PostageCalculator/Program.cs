using System;
using PostageCalculator.Classes;
using System.Collections.Generic;

namespace PostageCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the weight of the package: ");
            double weight = int.Parse(Console.ReadLine());
            Console.Write("(P)ounds or (O)unces? ");
            string units = Console.ReadLine().ToLower();
            Console.Write("What distance will you be traveling? ");
            int distance = int.Parse(Console.ReadLine());

                List<IDeliveryDriver> rates = new List<IDeliveryDriver>() { new FirstClass(), new SecondClass(), new ThirdClass(), new FexEd(), new FourDayGround(), new TwoDayBusiness(), new NextDay() };

            if (units == "p")
            {
                weight = weight * 16;
            }

           
            Console.WriteLine("{0, -30} {1,9}\n", "Shipping Method", "$ Cost");
            
            foreach (IDeliveryDriver shippingClass in rates)
            {
                Console.WriteLine("{0, -30} {1, 9}\n", shippingClass.Name, shippingClass.CalculateRate(distance, weight).ToString("C"));

            
            }
            



        }
    }
}

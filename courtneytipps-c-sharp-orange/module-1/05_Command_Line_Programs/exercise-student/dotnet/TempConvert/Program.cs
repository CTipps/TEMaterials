using System;

namespace TempConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a temperature:");
            string userInput = Console.ReadLine();
            double initialTemp = double.Parse(userInput);
            Console.WriteLine("Is it in (F)ahrenheit or (C)elsius?:");
            string conType = Console.ReadLine().ToUpper();
            if (conType == "F")
            {
                double degreesCel = (initialTemp - 32) / 1.8;
                Console.WriteLine(initialTemp + "F is " + degreesCel + "C.");
            }
            else if (conType == "C")
            {
                double degreesFar = (initialTemp * 1.8) + 32;
                Console.WriteLine(initialTemp + "C is " + degreesFar + "F.");
            }
            else
            {
                Console.WriteLine("I'm sorry, please enter F or C for your temperature type. Goodbye.");
            }

        }
    }
}
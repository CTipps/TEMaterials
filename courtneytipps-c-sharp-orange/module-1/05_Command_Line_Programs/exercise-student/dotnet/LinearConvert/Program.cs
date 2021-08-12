using System;

namespace LinearConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a length (ex 10):");
            string userInput = Console.ReadLine();
            double initialLength = double.Parse(userInput);
            Console.WriteLine("Is it in (f)eet or (m)eters?:");
            string conType = Console.ReadLine().ToLower();
            if (conType == "f")
            {
                double meters = initialLength * 0.3048;
                Console.WriteLine(initialLength + "f is " + meters + "m.");
            }
            else if (conType == "m")
            {
                double feet = initialLength * 3.2808399;
                Console.WriteLine(initialLength + "m is " + feet + "f.");
            }
            else
            {
                Console.WriteLine("I'm sorry, please enter f or m for your length type. Goodbye.");
            }

        }
    }
}

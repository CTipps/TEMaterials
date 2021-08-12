using System;

namespace DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter in a series of integer values (separated by spaces)");
            string userInput = Console.ReadLine();
            string[] inputIntegers = userInput.Split(' ');
            for (int i = 0; i < inputIntegers.Length; i++)
            {
                int inputInteger = int.Parse(inputIntegers[i]);
                string binary = Convert.ToString(inputInteger, 2);
                Console.WriteLine(inputInteger + " is " + binary + " in binary.");

            }
        }
    }
}

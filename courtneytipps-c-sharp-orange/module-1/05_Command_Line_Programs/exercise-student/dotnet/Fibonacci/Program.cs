using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a single integer (ex 34):");
            string userInput = Console.ReadLine();
            int number = int.Parse(userInput);
            int f1Number = 0;
            int f2Number = 1;
            if (number <= 0)
            {
                Console.WriteLine("0");
            }
            if (number == 1)
            {
                Console.WriteLine("0, 1, 1");
            }
            if (number > 1)
            {
                Console.Write(f1Number + " " + f2Number + " ");
                for (int i = 0; i <= number; i++)
                {
                    int f3Number = f1Number + f2Number;
                    if (f3Number > number)
                    {
                        break;
                    }
                    Console.Write(f3Number + " ");
                    f1Number = f2Number;
                    f2Number = f3Number;
                }
            }
        }
    }
}

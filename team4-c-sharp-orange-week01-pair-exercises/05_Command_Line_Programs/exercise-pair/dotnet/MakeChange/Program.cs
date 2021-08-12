using System;

namespace MakeChange
{
    class Program
    {
        /*
        Write a command line program which prompts the user for the total bill, and the amount tendered. It should then display the change required.

        C:\Users> MakeChange

        Please enter the amount of the bill: 23.65
        Please enter the amount tendered: 100.00
        The change required is 76.35
        */
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter total bill (ex. 20.25):");
            string userInput = Console.ReadLine();
            decimal totalBill = decimal.Parse(userInput);

            Console.WriteLine("Please enter amount tendered (ex 50.00):");
            userInput = Console.ReadLine();
            decimal amountPaid = decimal.Parse(userInput);

            decimal change = amountPaid - totalBill;

            Console.WriteLine("The change required is " + change.ToString("c"));

        }
    }
}

using System;
using Assessment.Models;

namespace Assessment
{
    class Program
    {
        static void Main(string[] args)
        { bool sameDay = false;
            // create an object and call methods on it
            // (manual testing) from this class.

            Console.Write("Please enter bouquet type (ex. Standard, Special) : ");
            string type = Console.ReadLine();
            Console.Write("Please enter number of roses (ex. 5, 7, 12): ");
            string roses = Console.ReadLine();
            FlowerShopOrder customerOrder = new FlowerShopOrder(type, roses);
            Console.Write("Please enter your zipcode (ex. 45356): ");
            string zipcode = Console.ReadLine();
            if (int.Parse(zipcode) < 39999 && int.Parse(zipcode) > 19999)
            {
                sameDay = customerOrder.SameDayShipping();
                Console.WriteLine(customerOrder.ToString());
            }
            else { Console.WriteLine(customerOrder.ToString()); }
        }
    }
}

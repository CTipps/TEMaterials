using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Models
{
    public class FlowerShopOrder
    {
        public string BouquetType { get; }
        public int NumberOfRoses { get; }
        public decimal Subtotal { get 
            {
                return 19.99M + (2.99M * NumberOfRoses); 
            }
        }

        public FlowerShopOrder(string bouquetType, string numberOfRoses)
        {
            BouquetType = bouquetType;
            NumberOfRoses = int.Parse(numberOfRoses);
        }

        public decimal DeliveryTotal(bool sameDayDelivery, string zipCode)
        {
            decimal deliveryTotal = 0.00M;
            if (int.Parse(zipCode) < 20000)
            {
                deliveryTotal = 0.00M;
            } else if (int.Parse(zipCode) < 30000)
            {
                deliveryTotal = 3.99M;
                if (sameDayDelivery)
                {
                    deliveryTotal += 5.99M;
                }
            }
            else if (int.Parse(zipCode) < 40000)
            {
                deliveryTotal = 6.99M;
                if (sameDayDelivery)
                {
                    deliveryTotal += 5.99M;
                }
            } else { deliveryTotal = 19.99M; }
            return deliveryTotal;
        }

        public override string ToString()
        {
            return $"ORDER - {BouquetType} - {NumberOfRoses} roses - ${Subtotal}";
        }

        public bool SameDayShipping()
        {
            Console.Write("Will this be same day delivery? Y/N: ");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "Y")
            {
                return true;
            }
            else { return false; }
        }
    }
}

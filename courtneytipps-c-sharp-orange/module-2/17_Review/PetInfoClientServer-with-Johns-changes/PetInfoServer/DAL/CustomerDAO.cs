using PetInfoServer.DAL.Interfaces;
using PetInfoServer.Models;
using System.Collections.Generic;

namespace PetInfoServer.DAL
{
    public class CustomerDAO: ICustomerDAO
    {
        private string connectionString;

        public CustomerDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Customer> GetCustomers()
        {
            Customer customer = new Customer
            {
                Name = "TestName",
                Email = "john@emai.com"
            };
            //doto fix dao method
            return new List<Customer> { customer };
        }
    }
}

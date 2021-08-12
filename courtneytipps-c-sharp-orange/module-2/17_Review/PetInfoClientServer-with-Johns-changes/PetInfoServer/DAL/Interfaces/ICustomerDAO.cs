using PetInfoServer.Models;
using System.Collections.Generic;


namespace PetInfoServer.DAL.Interfaces
{
    public interface ICustomerDAO
    {
        List<Customer> GetCustomers();
    }
}

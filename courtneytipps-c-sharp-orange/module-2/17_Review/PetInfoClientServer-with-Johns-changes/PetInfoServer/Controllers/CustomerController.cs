using Microsoft.AspNetCore.Mvc;
using PetInfoServer.DAL.Interfaces;
using PetInfoServer.Models;
using System.Collections.Generic;

namespace PetInfoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerDAO customerDAO;
        public CustomerController(ICustomerDAO customerDAO)
        {
            this.customerDAO = customerDAO;
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetCustomers()
        {
            return Ok(customerDAO.GetCustomers());
        }
    }
}

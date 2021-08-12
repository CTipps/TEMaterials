using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserDAO userDAO;

        public UsersController(IUserDAO _userDAO)
        {
            userDAO = _userDAO;
        }

        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            List<User> users = new List<User>();
            users = userDAO.GetUsers();
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet("{accountId}")]
        public ActionResult<User> GetUserByAccountId(int accountId)
        {
            User user = userDAO.GetUserByAccountId(accountId);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

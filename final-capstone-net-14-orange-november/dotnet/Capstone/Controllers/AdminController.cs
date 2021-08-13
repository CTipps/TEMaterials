using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.DAO;
using Capstone.DAO.Interfaces;

namespace Capstone.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdminDAO adminDAO;
        private IUserDAO userDAO;

        public AdminController(IAdminDAO adminDAO, IUserDAO userDAO)
        {
            this.adminDAO = adminDAO;
            this.userDAO = userDAO;
        }

        //todo [Authorize(Roles ="admin")]
        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            return Ok(userDAO.GetUsers());
        }

        [HttpGet("{userId}")]
        public ActionResult<User> GetUser(int userId)
        {
            return Ok(userDAO.GetUser(userId));
        }

        //todo [Authorize(Roles ="admin")]
        [HttpPut("users/{userId}")]
        public ActionResult<bool> UpdateUserRole(User user, int userId)
        {
            return Ok(adminDAO.UpdateUserRole(user));
        }

        //todo [Authorize(Roles ="admin")]
        [HttpDelete("{userId}")]
        public ActionResult<bool> DeleteUser(int userId)
        {
            return Ok(adminDAO.DeleteUser(userId));
        }

    }
}

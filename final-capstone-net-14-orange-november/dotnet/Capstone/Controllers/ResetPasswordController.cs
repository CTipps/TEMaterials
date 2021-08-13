using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.DAO;
using Capstone.DAO.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Capstone.Security;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResetPasswordController : ControllerBase
    {        
            private IAdminDAO adminDAO;
            private IUserDAO userDAO;

            public ResetPasswordController(IAdminDAO adminDAO, IUserDAO userDAO)
            {
                this.adminDAO = adminDAO;
                this.userDAO = userDAO;
            }

        [HttpGet("{resetCode}")]
        public ActionResult<User> GetUser(string resetCode)
        {
            return Ok(userDAO.GetUserFromPWResetCode(resetCode));
        }

        [HttpPut]
        public ActionResult<bool> UpdateUserPasswordInfo(ResetPassword resetPassword)
        {
            return Ok(adminDAO.UpdateUserPasswordInfo(resetPassword));
        }
        

        

    }
}

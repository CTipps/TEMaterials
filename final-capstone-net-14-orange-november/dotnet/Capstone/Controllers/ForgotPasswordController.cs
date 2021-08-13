using Capstone.DAO.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ForgotPasswordController : ControllerBase
    {
        private IAdminDAO adminDAO;
        private IUserDAO userDAO;

        public ForgotPasswordController(IAdminDAO adminDAO, IUserDAO userDAO)
        {
            this.adminDAO = adminDAO;
            this.userDAO = userDAO;
        }

        [HttpGet("{emailAddress}")]
        public ActionResult<string> GetUserResetCodeFromEmail(string emailAddress)
        {
            return Ok(userDAO.GetUserResetCodeFromEmail(emailAddress));
        }
    }
}

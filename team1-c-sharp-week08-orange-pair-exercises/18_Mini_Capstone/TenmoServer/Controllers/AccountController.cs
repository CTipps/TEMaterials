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
    public class AccountController : ControllerBase
    {
        private readonly IAccountDAO accountDAO;

        public AccountController(IAccountDAO _accountDAO)
        {
            accountDAO = _accountDAO;
        }

        //GET: /account/balance
        [HttpGet("balance")]
        public ActionResult<decimal> GetBalance()
        {
            decimal currentBalance = -1.0M;
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            currentBalance = accountDAO.GetBalance(userId);

            if (currentBalance >= 0)
            {
                return Ok(currentBalance);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("id")]
        public ActionResult<int> GetCurrentAccountId()
        {
            int accountId = 0;
            int userId = int.Parse(this.User.FindFirst("sub").Value);

            accountId = accountDAO.GetAccountIdFromUserId(userId);
            if (accountId > 0)
            {
                return Ok(accountId);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

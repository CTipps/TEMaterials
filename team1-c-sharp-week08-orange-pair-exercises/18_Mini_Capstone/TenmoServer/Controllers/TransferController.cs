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
    public class TransferController : ControllerBase
    {
        private readonly ITransferDAO transferDAO;

        public TransferController(ITransferDAO _transferDAO)
        {
            transferDAO = _transferDAO;
        }

        [HttpPost]
        public ActionResult<TransferDetails> TransferTEBucks(TransferDetails transferDetails)
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            bool success = transferDAO.TransferTEBucks(userId, transferDetails);
            if (success)
            {
                return Ok(transferDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("past")]
        public ActionResult<List<TransferDetails>> GetPastTransfers()
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);
            List<TransferDetails> pastTransfers = transferDAO.GetAcceptedTransfers(userId);
            if (pastTransfers != null)
            {
                return Ok(pastTransfers);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

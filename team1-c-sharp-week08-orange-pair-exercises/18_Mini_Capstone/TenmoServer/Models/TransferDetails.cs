using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenmoServer.Models
{
    public class TransferDetails
    {
        public int TransferId { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }

        public decimal TransferAmount { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
    }
}

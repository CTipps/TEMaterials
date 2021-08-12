using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface ITransferDAO
    {
        bool TransferTEBucks(int userId, TransferDetails transferDetails);
        List<TransferDetails> GetAcceptedTransfers(int userId);
    }
}

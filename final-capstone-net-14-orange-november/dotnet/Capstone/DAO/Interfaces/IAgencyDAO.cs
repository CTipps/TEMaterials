using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO.Interfaces
{
   public interface IAgencyDAO
    {
        bool AddAgency(Agency agency);

        IEnumerable<Agency> GetAllAgencies();
        Agency GetAgency(int agencyId);
        bool UpdateAgency(Agency agency);
        bool DeleteAgency(int agencyId);
    }
}

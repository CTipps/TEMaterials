using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.Security;

namespace Capstone.DAO.Interfaces
{
   public interface IAdminDAO
    {
        bool UpdateUserRole(User user);
        bool DeleteUser(int userId);
        bool UpdateUserPasswordInfo(ResetPassword resetPassword);
    }
}

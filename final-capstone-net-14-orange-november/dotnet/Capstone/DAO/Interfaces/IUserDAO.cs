using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface IUserDAO
    {
        User GetUser(string username);
        User GetUser(int userId);
        List<User> GetUsers();
        User AddUser(string username, string password, string email, string role);

        User GetUserFromPWResetCode(string resetCode);
        string GetUserResetCodeFromEmail(string emailAddress);
    }
}

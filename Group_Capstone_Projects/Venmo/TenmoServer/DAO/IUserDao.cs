using System.Collections.Generic;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface IUserDao
    {
        User GetUserById(int id);

        User GetUserByAccountId(int accountId);
        User GetUserByUsername(string username);
        User CreateUser(string username, string password);
        IList<User> GetUsers();
    }
}

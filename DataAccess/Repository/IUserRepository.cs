using DataAccess.Infrastructure;
using ModelLayer.Model;

namespace DataAccess.Repository;

public interface IUserRepository : IGeneric<User>
{
    User Login(string username, string password);
    User GetEmail(string email);
    User GetUsername(string username);
    User UpdateUser(User user);
    bool GetAdminAccount(string us, string pass);
}
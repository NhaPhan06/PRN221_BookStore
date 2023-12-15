using DataAccess.Infrastructure;
using ModelLayer.Model;

namespace DataAccess.Repository;

public interface IUserRepository : IGeneric<User>
{
    User Login(string username, string password);
    User GetEmailUsername(string email, string username);
    User UpdateUser(User user);
}
using DataAccess.DTOS.Auth;
using DataAccess.Model;
using ModelLayer.Model;

namespace BusinessLayer.Service;

public interface IUserService
{
    User Login(string username, string password);
    User CheckEmailUsername(string email, string username);
    void CreateUser(CreateUser createUser);
    User GetUserById(Guid id);
    User UpdateUser(Guid id, User user);
    Task<List<User>> GetAll();
    void BanUser(Guid guid);
    void UnbanUser(Guid guid);
    bool GetAdminAccount(string username, string password);
    AuthenticationResult LoginCheckRole(string username, string password);
}
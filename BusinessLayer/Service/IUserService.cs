using DataAccess.DataAccess;
using DataAccess.Model;

namespace BusinessLayer.Service {
    public interface IUserService {
        User Login(string username, string password);
        User CheckEmailUsername(string email, string username);
        void CreateUser(CreateUser createUser);
        User GetUserById(Guid id);
        User UpdateUser(Guid id, User user);
    }
}
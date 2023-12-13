using BusinessLayer.DTOS.User;
using DataAccess.DataAccess;

namespace BusinessLayer.Service {
    public interface IUserService {
        User Login(string username, string password);
        User CheckEmailUsername(string email, string username);
        void CreateUser(CreateUser createUser);
    }
}
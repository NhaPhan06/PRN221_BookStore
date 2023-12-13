using DataAccess.DataAccess;

namespace BusinessLayer.Service {
    public interface IUserService {
        User Login(string username, string password);
    }
}
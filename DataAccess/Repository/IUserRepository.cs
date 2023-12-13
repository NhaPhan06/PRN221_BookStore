using DataAccess.DataAccess;
using DataAccess.Repository.Generic;

namespace DataAccess.Repository {
    public interface IUserRepository : IGeneric<User> {
        User Login(string username, string password);
    }
}
using DataAccess.DataAccess;
using DataAccess.Repository.Implement.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Implement {
    public class UserRepository : Generic<User>, IUserRepository {
        public UserRepository(PRN_BookStoreContext context) : base(context) {
        }

        public User Login(string username, string password)
        {
            var user = _context.Set<User>().FirstOrDefault(a => a.Username.Equals(username) && a.Password.Equals(password));
            return user;
        }
    }
}
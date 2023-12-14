using DataAccess.DataAccess;
using DataAccess.Repository.Implement.Generic;

namespace DataAccess.Repository.Implement {
    public class UserRepository : Generic<User>, IUserRepository {
        public UserRepository(PRN_BookStoreContext context) : base(context) {
        }

        public User GetEmailUsername(string email, string username) {
            User? account = _context.Set<User>()
                .FirstOrDefault(a => a.Email.Equals(email) || a.Username.Equals(username));
            return account;
        }

        public User Login(string username, string password) {
            User? user = _context.Set<User>()
                .FirstOrDefault(a => a.Username.Equals(username) && a.Password.Equals(password));
            return user;
        }

        public User UpdateUser(User user) {
            _context.Set<User>().Update(user);
            return user;
        }
    }
}
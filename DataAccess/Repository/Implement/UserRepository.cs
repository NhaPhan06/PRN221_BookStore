using DataAccess.DataAccess;
using DataAccess.Repository.Implement.Generic;

namespace DataAccess.Repository.Implement {
    public class UserRepository : Generic<User>, IUserRepository {
        public UserRepository(PRN_BookStoreContext context) : base(context) {
        }
    }
}
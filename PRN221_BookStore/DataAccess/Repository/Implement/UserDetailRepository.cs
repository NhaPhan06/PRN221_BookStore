using DataAccess.DataAccess;
using DataAccess.Repository.Implement.Generic;

namespace DataAccess.Repository.Implement;

public class UserDetailRepository : Generic<UserDetail>, IUserDetailRepository
{
    public UserDetailRepository(PRN_BookStoreContext context) : base(context)
    {
    }
}
﻿using DataAccess.DataAccess;
using DataAccess.Repository.Generic;

namespace DataAccess.Repository {
    public interface IUserRepository : IGeneric<User> {
        User Login(string username, string password);
        User GetEmailUsername(string email, string username);
        User UpdateUser(User user);
    }
}
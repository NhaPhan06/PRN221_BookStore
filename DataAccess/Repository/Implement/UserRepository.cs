using DataAccess.Infrastructure;
using Microsoft.Extensions.Configuration;
using ModelLayer.Model;

namespace DataAccess.Repository.Implement;

public class UserRepository : Generic<User>, IUserRepository
{
    public UserRepository(PRN_BookStoreContext context) : base(context)
    {
    }

    public bool GetAdminAccount(string us, string pass)
    {
        IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

        // Check if the configuration key exists
        if (config.GetSection("AdminAccount").Exists())
        {
            string emailJson = config["AdminAccount:adminemail"];
            string passwordJson = config["AdminAccount:adminpassword"];

            // Check if both email and password match
            if (emailJson == us && passwordJson == pass)
            {
                return true;
            }
        }

        return false;
    }

    public User GetEmail(string email)
    {
        var account = _context.Set<User>()
            .FirstOrDefault(a => a.Email.Equals(email));
        return account;
    }

    

    public User GetUsername(string username)
    {
        var account = _context.Set<User>()
            .FirstOrDefault(a => a.Username.Equals(username));
        return account;
    }

    public User Login(string username, string password)
    {
        var user = _context.Set<User>()
            .FirstOrDefault(a => a.Username.Equals(username) && a.Password.Equals(password));
        return user;
    }

    public User UpdateUser(User user)
    {
        _context.Set<User>().Update(user);
        return user;
    }
}
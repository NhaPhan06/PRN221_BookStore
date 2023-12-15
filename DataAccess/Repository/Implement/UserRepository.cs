using DataAccess.Infrastructure;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
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

    public Task<List<User>> GetUsers(GetUserDto getUserDto) {
        var query = _context.Set<User>().AsQueryable();
        
        if (!string.IsNullOrEmpty(getUserDto.Username)) {
            query = query.Where(a => a.Username.Contains(getUserDto.Username));
        }

        switch (getUserDto.SortField) {
            case UserSortField.Username:
                query= getUserDto.SortDirection == SortDirection.Asc? query.OrderBy(a => a.Username) : query.OrderByDescending(a => a.Username);
                break;
            
            case UserSortField.Email:
                query= getUserDto.SortDirection == SortDirection.Asc? query.OrderBy(a => a.Email) : query.OrderByDescending(a => a.Email);
                break;
            
            case UserSortField.Birthdate:
                query= getUserDto.SortDirection == SortDirection.Asc? query.OrderBy(a => a.Birthdate) : query.OrderByDescending(a => a.Birthdate);
                break;
            
            case UserSortField.Status:
                query= getUserDto.SortDirection == SortDirection.Asc? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status);
                break;
        }
        
        return query.ToListAsync();
    }
}
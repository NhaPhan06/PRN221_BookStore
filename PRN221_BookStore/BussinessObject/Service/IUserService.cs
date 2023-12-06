using BussinessObject.Model.Request;

namespace BussinessObject.Service;

public interface IUserService
{
    public Task CreateCustomer(CreateUser user);
    
    public Task CreateAdmin(CreateUser user);
}
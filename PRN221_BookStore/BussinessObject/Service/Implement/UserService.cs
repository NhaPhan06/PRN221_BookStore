using AutoMapper;
using BussinessObject.Model.Request;
using DataAccess.DataAccess;
using DataAccess.Generic.UnitOfWork;

namespace BussinessObject.Service.Implement;

public class UserService : IUserService
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task CreateCustomer(CreateUser user)
    {
        var customer = _mapper.Map<UserDetail>(user);
        customer.User.Role = "CUSTOMER";
        _unitOfWork.UserDetailRepository.Add(customer);
        _unitOfWork.Save();
        return Task.CompletedTask;
    }

    public Task CreateAdmin(CreateUser user)
    {
        var admin = _mapper.Map<UserDetail>(user);
        admin.User.Role = "ADMIN";
        _unitOfWork.UserDetailRepository.Add(admin);
        _unitOfWork.Save();
        return Task.CompletedTask;
    }
}
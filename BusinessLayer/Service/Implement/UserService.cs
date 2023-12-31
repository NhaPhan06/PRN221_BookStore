﻿using DataAccess.DTOS.Auth;
using DataAccess.Infrastructure;
using DataAccess.Model;
using ModelLayer.Model;

namespace BusinessLayer.Service.Implement;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public User CheckEmail(string email)
    {
        var account = _unitOfWork.UserRepository.GetEmail(email);
        if (account != null) return account;

        return null;
    }
    public User CheckUsername(string username)
    {
        var account = _unitOfWork.UserRepository.GetUsername(username);
        if (account != null) return account;

        return null;
    }

    public void CreateUser(CreateUser createUser)
    {
        User newUser = new();
        newUser.UserId = new Guid();
        newUser.Status = "ACTIVE";
        newUser.Email = createUser.Email;
        newUser.Username = createUser.Username;
        newUser.Password = createUser.Password;
        newUser.Address = createUser.Address;
        newUser.PhoneNumber = createUser.PhoneNumber;
        newUser.City = createUser.City;
        newUser.Birthdate = createUser.Birthdate;
        newUser.Firstname = createUser.Firstname;
        newUser.Lastname = createUser.Lastname;
        _unitOfWork.UserRepository.Add(newUser);
        _unitOfWork.Save();
    }

    public User GetUserById(Guid id)
    {
        return _unitOfWork.UserRepository.GetById(id);
    }

    public User Login(string username, string password)
    {
        var user = _unitOfWork.UserRepository.Login(username, password);
        if (user != null) return user;

        return null;
    }

    public User UpdateUser(Guid id, User user)
    {
        var us = _unitOfWork.UserRepository.GetById(id);
        if (us.Firstname == user.Firstname &&
            us.Lastname == user.Lastname &&
            us.City == user.City &&
            us.Address == user.Address &&
            us.PhoneNumber == user.PhoneNumber)
            throw new Exception("Nothing Change!");

        us.Firstname = user.Firstname;
        us.Lastname = user.Lastname;
        us.City = user.City;
        us.Address = user.Address;
        us.PhoneNumber = user.PhoneNumber;
        var update = _unitOfWork.UserRepository.UpdateUser(us);
        _unitOfWork.Save();
        return update;
    }

    public Task<List<User>> GetAll()
    {
        var data = _unitOfWork.UserRepository.GetAll().ToList();
        return Task.FromResult(data);
    }

    public void BanUser(Guid guid) {
        var user = _unitOfWork.UserRepository.GetById(guid);
        user.Status = Status.Inactive;
        _unitOfWork.UserRepository.UpdateUser(user);
        _unitOfWork.Save();
    }

    public void UnbanUser(Guid guid) {
        var user = _unitOfWork.UserRepository.GetById(guid);
        user.Status = Status.Active;
        _unitOfWork.UserRepository.UpdateUser(user);
        _unitOfWork.Save();
    }

    public bool GetAdminAccount(string username, string password)
    {
        return _unitOfWork.UserRepository.GetAdminAccount(username, password);
    }

    public AuthenticationResult LoginCheckRole(string username, string password)
    {
        bool checkAdmin = _unitOfWork.UserRepository.GetAdminAccount(username,password);
        if(checkAdmin is true)
        {
            AuthenticationResult result = new() { IsAuthenticated = true, Role = UserRole.Admin, Email = username };
            return result;
        }
        
        if(_unitOfWork.UserRepository.Login(username, password) != null)
        {
            AuthenticationResult result = new() { IsAuthenticated = true, Role = UserRole.Customer, Email = username };
            return result;
        }
        return new AuthenticationResult { IsAuthenticated = false };  
    }
    
    public Task<List<User>> GetUsers(GetUserDto getUserDto) {
        var data = _unitOfWork.UserRepository.GetUsers(getUserDto);
        return data;
    }
}
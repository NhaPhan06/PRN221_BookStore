using AutoMapper;
using BussinessObject.Model.Request;
using DataAccess.DataAccess;

namespace BussinessObject.Mapper;

public class ApplicationMapper: Profile
{
    public ApplicationMapper()
    {
        CreateMap<CreateUser, UserDetail>()
            .ForMember(c => c.UserDetailId
                , act => act.MapFrom(src => Guid.NewGuid()))
            .ForMember(c => c.Firstname, act => act.MapFrom(src => src.Firstname))
            .ForMember(c => c.Lastname, act => act.MapFrom(src => src.Lastname))
            .ForMember(c => c.City, act => act.MapFrom(src => src.City))
            .ForMember(c => c.Address, act => act.MapFrom(src => src.Address))
            .ForMember(c => c.PhoneNumber, act => act.MapFrom(src => src.PhoneNumber))
            .ForMember(c => c.Birthdate, act => act.MapFrom(src => src.Birthdate))
            .ForMember(c => c.User, act => act.MapFrom(src => new User
            {
                UserId = Guid.NewGuid(),
                Username = src.Username,
                Password = src.Password,
                Email = src.Email
            }));
    }
}
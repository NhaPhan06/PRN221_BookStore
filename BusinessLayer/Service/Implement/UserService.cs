using BusinessLayer.DTOS.User;
using DataAccess.DataAccess;
using DataAccess.Repository.Generic.UnitOfWork;

namespace BusinessLayer.Service.Implement {
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User CheckEmailUsername(string email, string username)
        {
            var account = _unitOfWork.UserRepository.GetEmailUsername(email,username);
            if (account != null) return account;
            return null;
        }

        public void CreateUser(CreateUser createUser)
        {
            User newUser = new User();
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

        public User Login(string username, string password)
        {
            var user = _unitOfWork.UserRepository.Login(username, password);
            if (user != null) return user;
            return null;
        }
    }
}
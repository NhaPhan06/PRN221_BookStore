using DataAccess.DataAccess;
using DataAccess.Model;
using DataAccess.Repository.Generic.UnitOfWork;

namespace BusinessLayer.Service.Implement {
    public class UserService : IUserService {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public User CheckEmailUsername(string email, string username) {
            User? account = _unitOfWork.UserRepository.GetEmailUsername(email, username);
            if (account != null) {
                return account;
            }

            return null;
        }

        public void CreateUser(CreateUser createUser) {
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

        public User GetUserById(Guid id) {
            return _unitOfWork.UserRepository.GetById(id);
        }

        public User Login(string username, string password) {
            User? user = _unitOfWork.UserRepository.Login(username, password);
            if (user != null) {
                return user;
            }

            return null;
        }

        public User UpdateUser(Guid id, User user) {
            User us = _unitOfWork.UserRepository.GetById(id);
            if (us.Firstname == user.Firstname &&
                us.Lastname == user.Lastname &&
                us.City == user.City &&
                us.Address == user.Address &&
                us.PhoneNumber == user.PhoneNumber) {
                throw new Exception("Nothing Change!");
            }

            us.Firstname = user.Firstname;
            us.Lastname = user.Lastname;
            us.City = user.City;
            us.Address = user.Address;
            us.PhoneNumber = user.PhoneNumber;
            User update = _unitOfWork.UserRepository.UpdateUser(us);
            _unitOfWork.Save();
            return update;
        }

        public Task<List<User>> GetAll() {
            var data  =  _unitOfWork.UserRepository.GetAll().ToList();
            return Task.FromResult(data);
        }
    }
}
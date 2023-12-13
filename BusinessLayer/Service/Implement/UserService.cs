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

        public User Login(string username, string password)
        {
            var user = _unitOfWork.UserRepository.Login(username, password);
            if (user != null) return user;
            return null;
        }
    }
}
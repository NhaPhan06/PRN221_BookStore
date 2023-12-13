using DataAccess.DataAccess;
using DataAccess.Repository.Generic.UnitOfWork;

namespace BusinessLayer.Service.Implement {
    public class CategoryService : ICategoryService {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Category>> GetAll() {
            IEnumerable<Category> result = _unitOfWork.CategoryRepository.GetAll();
            return Task.FromResult(result);
        }
    }
}
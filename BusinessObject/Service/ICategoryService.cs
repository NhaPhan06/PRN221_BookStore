using DataAccess.DataAccess;

namespace BusinessObject.Service {
    public interface ICategoryService {
        Task<IEnumerable<Category>> GetAll();
    }
}
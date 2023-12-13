using DataAccess.DataAccess;

namespace BusinessLayer.Service {
    public interface ICategoryService {
        Task<IEnumerable<Category>> GetAll();
    }
}
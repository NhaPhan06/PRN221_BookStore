using ModelLayer.Model;

namespace BusinessLayer.Service;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAll();
}
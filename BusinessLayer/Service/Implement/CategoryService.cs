using DataAccess.Infrastructure;
using ModelLayer.Model;

namespace BusinessLayer.Service.Implement;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<Category>> GetAll()
    {
        var result = _unitOfWork.CategoryRepository.GetAll();
        return Task.FromResult(result);
    }
}
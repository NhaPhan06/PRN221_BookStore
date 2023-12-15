using DataAccess.Infrastructure;
using ModelLayer.Model;

namespace DataAccess.Repository.Implement;

public class CategoryRepository : Generic<Category>, ICategoryRepository
{
    public CategoryRepository(PRN_BookStoreContext context) : base(context)
    {
    }
}
using DataAccess.DataAccess;
using DataAccess.Repository.Implement.Generic;

namespace DataAccess.Repository.Implement {
    public class CategoryRepository : Generic<Category>, ICategoryRepository {
        public CategoryRepository(PRN_BookStoreContext context) : base(context) {
        }
    }
}
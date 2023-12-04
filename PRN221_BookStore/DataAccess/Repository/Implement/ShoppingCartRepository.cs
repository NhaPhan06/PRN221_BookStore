using DataAccess.DataAccess;
using DataAccess.Repository.Implement.Generic;

namespace DataAccess.Repository.Implement;

public class ShoppingCartRepository : Generic<ShoppingCart>, IShoppingCartRepository
{
    public ShoppingCartRepository(PRN_BookStoreContext context) : base(context)
    {
    }
}
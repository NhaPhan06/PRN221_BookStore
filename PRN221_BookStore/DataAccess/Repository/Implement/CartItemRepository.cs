using DataAccess.DataAccess;
using DataAccess.Repository.Implement.Generic;

namespace DataAccess.Repository.Implement;

public class CartItemRepository : Generic<CartItem>, ICartItemRepository
{
    public CartItemRepository(PRN_BookStoreContext context) : base(context)
    {
    }
}
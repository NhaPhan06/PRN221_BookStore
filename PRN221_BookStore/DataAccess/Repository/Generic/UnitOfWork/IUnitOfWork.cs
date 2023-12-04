using DataAccess.DataAccess;
using DataAccess.Repository;

namespace DataAccess.Generic.UnitOfWork;

public interface IUnitOfWork
{
    IBookRepository BookRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IUserRepository UserRepository { get; }
    IOrderRepository OrderRepository { get; }
    IOrderDetailRepository OrderDetailRepository { get; }
    IUserDetailRepository UserDetailRepository { get; }
    IShoppingCartRepository ShoppingCartRepository { get; }
    ICartItemRepository CartItemRepository { get; }
    void Save();
}
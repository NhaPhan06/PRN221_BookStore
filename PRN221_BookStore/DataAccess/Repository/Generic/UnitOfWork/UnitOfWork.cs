using DataAccess.DataAccess;
using DataAccess.Repository;
using DataAccess.Repository.Implement;

namespace DataAccess.Generic.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public readonly PRN_BookStoreContext _context;

    public UnitOfWork(PRN_BookStoreContext context)
    {
        // ReSharper disable once RedundantAssignment
        _context = context;
        BookRepository = new BookRepository(_context);
        CategoryRepository = new CategoryRepository(_context);
        UserRepository = new UserRepository(_context);
        OrderRepository = new OrderRepository(_context);
        OrderDetailRepository = new OrderDetailRepository(_context);
        UserDetailRepository = new UserDetailRepository(_context);
        ShoppingCartRepository = new ShoppingCartRepository(_context);
        CartItemRepository = new CartItemRepository(_context);
    }
    
    public IBookRepository BookRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IUserRepository UserRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public IOrderDetailRepository OrderDetailRepository { get; }
    public IUserDetailRepository UserDetailRepository { get; }
    public IShoppingCartRepository ShoppingCartRepository { get; }
    public ICartItemRepository CartItemRepository { get; }

    public void Save()
    {
        _context.SaveChanges();
    }
}
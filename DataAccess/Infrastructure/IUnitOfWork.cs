using DataAccess.Repository;

namespace DataAccess.Infrastructure;

public interface IUnitOfWork
{
    IBookRepository BookRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IUserRepository UserRepository { get; }
    IOrderRepository OrderRepository { get; }
    IOrderDetailRepository OrderDetailRepository { get; }
    void Save();
}
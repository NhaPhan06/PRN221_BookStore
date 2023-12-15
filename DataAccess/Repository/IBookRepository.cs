using DataAccess.Infrastructure;
using DataAccess.Model;
using ModelLayer.Model;

namespace DataAccess.Repository;

public interface IBookRepository : IGeneric<Book>
{
    Task<List<Book>> GetBookList(GetBooksDto getBooksDto);
    Task<int> GetBookCount(GetBooksDto getBooksDto);
    Task<Book?> GetDetail(string id);
}
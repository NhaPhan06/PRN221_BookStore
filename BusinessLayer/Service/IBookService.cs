using DataAccess.Model;
using ModelLayer.Model;

namespace BusinessLayer.Service;

public interface IBookService
{
    Task<List<Book>> GetAll();
    Task<List<Book>> GetBookList(GetBooksDto getBooksDto);
    Task<int> CountBookList(GetBooksDto getBooksDto);
    void Add(Book book);
    Task<Book?> GetDetail(string id);
    Task<Book> GetBookById(Guid id);
    List<Book> GetRandom3Books();
}
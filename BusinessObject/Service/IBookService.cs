using BusinessObject.Model;
using DataAccess.DataAccess;

namespace BusinessObject.Service {
    public interface IBookService {
        Task<IEnumerable<Book>> GetAll();
        Task<IEnumerable<Book>> GetBookList(GetBooksDto getBooksDto);
        Task<int> CountBookList(GetBooksDto getBooksDto);
        void Add(Book book);
    }
}
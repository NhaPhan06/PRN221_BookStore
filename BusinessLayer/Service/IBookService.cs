using DataAccess.DataAccess;
using DataAccess.Model;

namespace BusinessLayer.Service {
    public interface IBookService {
        Task<List<Book>> GetAll();
        Task<List<Book>> GetBookList(GetBooksDto getBooksDto);
        Task<int> CountBookList(GetBooksDto getBooksDto);
        void Add(Book book);
    }
}
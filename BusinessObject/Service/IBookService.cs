using DataAccess.DataAccess;

namespace BusinessObject.Service {
    public interface IBookService {
        Task<IEnumerable<Book>> GetAll();
    }
}
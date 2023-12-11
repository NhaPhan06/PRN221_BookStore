using DataAccess.DataAccess;
using DataAccess.Generic.UnitOfWork;

namespace BusinessObject.Service.Implement {
    public class BookService : IBookService {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Book>> GetAll() {
            IEnumerable<Book> books = _unitOfWork.BookRepository.GetAll();
            return Task.FromResult(books);
        }
    }
}
using DataAccess.DataAccess;
using DataAccess.Model;
using DataAccess.Repository.Generic.UnitOfWork;

namespace BusinessObject.Service.Implement {
    public class BookService : IBookService {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public Task<List<Book>> GetAll() {
            IEnumerable<Book> result = _unitOfWork.BookRepository.GetAll();
            return Task.FromResult(result.ToList());
        }

        public Task<List<Book>> GetBookList(GetBooksDto getBooksDto) {
            return _unitOfWork.BookRepository.GetBookList(getBooksDto);
        }

        public Task<int> CountBookList(GetBooksDto getBooksDto) {
            var result = _unitOfWork.BookRepository.GetBookCount(getBooksDto); 
            return result;
        }

        public void Add(Book book) {
            _unitOfWork.BookRepository.Add(book);
            _unitOfWork.Save();
        }
    }
}
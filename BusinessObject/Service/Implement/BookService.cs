using BusinessObject.Model;
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
            IEnumerable<Category> categories = _unitOfWork.CategoryRepository.GetAll();

            IEnumerable<Book> data = from book in books
                join category in categories
                    on book.CategoryId equals category.CategoryId
                select new Book {
                    BookId = book.BookId,
                    Title = book.Title,
                    Author = book.Author,
                    Isbn = book.Isbn,
                    Price = book.Price,
                    ImageUrl = book.ImageUrl,
                    Status = book.Status,
                    StockQuantity = book.StockQuantity,
                    Description = book.Description,
                    CategoryId = book.CategoryId,
                    Category = category
                };

            return Task.FromResult(data);
        }

        public Task<IEnumerable<Book>> GetBookList(GetBooksDto getBooksDto) {
            IEnumerable<Book> books = _unitOfWork.BookRepository.GetAll();
            IEnumerable<Category> categories = _unitOfWork.CategoryRepository.GetAll();

            IEnumerable<Book> query = from book in books
                join category in categories
                    on book.CategoryId equals category.CategoryId
                select new Book {
                    BookId = book.BookId,
                    Title = book.Title,
                    Author = book.Author,
                    Isbn = book.Isbn,
                    Price = book.Price,
                    ImageUrl = book.ImageUrl,
                    Status = book.Status,
                    StockQuantity = book.StockQuantity,
                    Description = book.Description,
                    CategoryId = book.CategoryId,
                    Category = category
                };

            if (!string.IsNullOrEmpty(getBooksDto.Title)) {
                query = query.Where(book => book.Title.Contains(getBooksDto.Title));
            }

            if (!string.IsNullOrEmpty(getBooksDto.Category)) {
                query = query.Where(book => book.Category.Name.Contains(getBooksDto.Category));
            }

            if (getBooksDto.Sort is { Field: not null, Direction: not null }) {
                string sortField = getBooksDto.Sort.Field;
                string sortDirection = getBooksDto.Sort.Direction;

                switch (sortField) {
                    case SortField.Title:
                        query = sortDirection == SortDirection.Asc
                            ? query.OrderBy(book => book.Title)
                            : query.OrderByDescending(book => book.Title);
                        break;
                    case SortField.Category:
                        query = sortDirection == SortDirection.Asc
                            ? query.OrderBy(book => book.Category.Name)
                            : query.OrderByDescending(book => book.Category.Name);
                        break;
                    case SortField.Price:
                        query = sortDirection == SortDirection.Asc
                            ? query.OrderBy(book => book.Price)
                            : query.OrderByDescending(book => book.Price);
                        break;
                    case SortField.Status:
                        query = sortDirection == SortDirection.Asc
                            ? query.OrderBy(book => book.Status)
                            : query.OrderByDescending(book => book.Status);
                        break;
                    case SortField.Stock:
                        query = sortDirection == SortDirection.Asc
                            ? query.OrderBy(book => book.StockQuantity)
                            : query.OrderByDescending(book => book.StockQuantity);
                        break;
                }
            }

            int currentPage = getBooksDto.CurrentPage <= 0 ? 1 : getBooksDto.CurrentPage;
            int pageSize = getBooksDto.PageSize <= 0 ? 10 : getBooksDto.PageSize;
            query = query.Skip((currentPage - 1) * pageSize).Take(pageSize);

            return Task.FromResult(query);
        }

        public Task<int> CountBookList(GetBooksDto getBooksDto) {
            IEnumerable<Book> books = _unitOfWork.BookRepository.GetAll();
            IEnumerable<Category> categories = _unitOfWork.CategoryRepository.GetAll();

            IEnumerable<Book> query = from book in books
                join category in categories
                    on book.CategoryId equals category.CategoryId
                select new Book {
                    BookId = book.BookId,
                    Title = book.Title,
                    Author = book.Author,
                    Isbn = book.Isbn,
                    Price = book.Price,
                    ImageUrl = book.ImageUrl,
                    Status = book.Status,
                    StockQuantity = book.StockQuantity,
                    Description = book.Description,
                    CategoryId = book.CategoryId,
                    Category = category
                };

            if (!string.IsNullOrEmpty(getBooksDto.Title)) {
                query = query.Where(book => book.Title.Contains(getBooksDto.Title));
            }

            if (!string.IsNullOrEmpty(getBooksDto.Category)) {
                query = query.Where(book => book.Category.Name.Contains(getBooksDto.Category));
            }

            return Task.FromResult(query.Count());
        }

        public void Add(Book book) {
            _unitOfWork.BookRepository.Add(book);
            _unitOfWork.Save();
        }
    }
}
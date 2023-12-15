using DataAccess.Infrastructure;
using DataAccess.Model;
using ModelLayer.Model;

namespace BusinessLayer.Service.Implement;

public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;

    public BookService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<Book>> GetAll()
    {
        var result = _unitOfWork.BookRepository.GetAll();
        return Task.FromResult(result.ToList());
    }

    public Task<List<Book>> GetBookList(GetBooksDto getBooksDto)
    {
        return _unitOfWork.BookRepository.GetBookList(getBooksDto);
    }

    public Task<int> CountBookList(GetBooksDto getBooksDto)
    {
        var result = _unitOfWork.BookRepository.GetBookCount(getBooksDto);
        return result;
    }

    public void Add(Book book)
    {
        _unitOfWork.BookRepository.Add(book);
        _unitOfWork.Save();
    }

    public async Task<Book> GetBookById(Guid id)
    {
        return _unitOfWork.BookRepository.GetById(id);
    }

    public Task<Book?> GetDetail(string id)
    {
        var result = _unitOfWork.BookRepository.GetDetail(id);
        return result;
    }

    public void SoftDelete(Book toBeDeleted)
    {
        toBeDeleted.Status = Status.Inactive;
        _unitOfWork.BookRepository.Update(toBeDeleted);
    }

    public void UpdateBook(Book toBeUpdated)
    {
        _unitOfWork.BookRepository.Update(toBeUpdated);
    }

    public List<Book> GetRandom3Books()
    {
        return _unitOfWork.BookRepository.GetRandom3Books();
    }
}
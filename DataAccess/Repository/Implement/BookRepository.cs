using DataAccess.Infrastructure;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Model;

namespace DataAccess.Repository.Implement;

public class BookRepository : Generic<Book>, IBookRepository
{
    public BookRepository(PRN_BookStoreContext context) : base(context)
    {
    }


    public Task<List<Book>> GetBookList(GetBooksDto getBooksDto)
    {
        var query = _context.Books.AsQueryable();

        query = query.Include(x => x.Category);

        if (!string.IsNullOrEmpty(getBooksDto.Title))
            query = query.Where(book => book.Title.Contains(getBooksDto.Title));

        if (!string.IsNullOrEmpty(getBooksDto.Category))
            query = query.Where(book => book.Category.Name.Contains(getBooksDto.Category));

        query.Where(x => x.Status == Status.Active);

        if (getBooksDto.Sort is { Field: not null, Direction: not null })
        {
            var sortField = getBooksDto.Sort.Field;
            var sortDirection = getBooksDto.Sort.Direction;

            switch (sortField)
            {
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

        var currentPage = getBooksDto.CurrentPage <= 0 ? 1 : getBooksDto.CurrentPage;
        var pageSize = getBooksDto.PageSize <= 0 ? 10 : getBooksDto.PageSize;
        query = query.Skip((currentPage - 1) * pageSize).Take(pageSize);

        var result = query.ToListAsync();

        return result;
    }

    public Task<int> GetBookCount(GetBooksDto getBooksDto)
    {
        var query = _context.Books.AsQueryable();

        query = query.Include(x => x.Category);

        if (!string.IsNullOrEmpty(getBooksDto.Title))
            query = query.Where(book => book.Title.Contains(getBooksDto.Title));

        if (!string.IsNullOrEmpty(getBooksDto.Category))
            query = query.Where(book => book.Category.Name.Contains(getBooksDto.Category));

        query.Where(x => x.Status == Status.Active);


        var result = query.CountAsync();

        return result;
    }

    public Task<Book?> GetDetail(string id)
    {
        var query = _context.Books.AsQueryable();

        Guid.TryParse(id, out var guid);

        query = query.Include(x => x.Category);
        query = query.Where(book => book.BookId.Equals(guid));

        var result = query.FirstOrDefaultAsync();

        return result;
    }

    public List<Book> GetRandom3Books()
    {
        var list = _context.Set<Book>().OrderBy(c => Guid.NewGuid()).Take(3).ToList();
        return list;
    }
}
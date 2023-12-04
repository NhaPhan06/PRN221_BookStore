using DataAccess.DataAccess;
using DataAccess.Repository.Implement.Generic;

namespace DataAccess.Repository.Implement;

public class BookRepository : Generic<Book>, IBookRepository
{
    public BookRepository(PRN_BookStoreContext context) : base(context)
    {
    }
}
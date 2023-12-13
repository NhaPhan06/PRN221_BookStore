using BusinessLayer.Service;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages {
    public class Shop : PageModel {
        private readonly IBookService _bookService;

        public Shop(IBookService bookService) {
            _bookService = bookService;
        }

        [BindProperty(SupportsGet = true)] public string Title { get; set; } = default!;

        [BindProperty(SupportsGet = true)] public string Category { get; set; } = default!;

        [BindProperty(SupportsGet = true)] public int CurrentPage { get; set; } = 1;

        [BindProperty(SupportsGet = true)] public int PageSize { get; set; } = 6;

        [BindProperty(SupportsGet = true)] public string SortBy { get; set; } = default!;

        [BindProperty(SupportsGet = true)] public string SortOrder { get; set; } = default!;

        public int TotalPages { get; set; }

        public IList<DataAccess.DataAccess.Book> Book { get; set; } = default!;

        public async Task OnGetAsync() {
            // IEnumerable<DataAccess.DataAccess.Book>? books = await _bookService.GetAll();
            GetBooksDto getBooksDto = new() {
                Title = Title,
                Category = Category,
                CurrentPage = CurrentPage,
                PageSize = PageSize,
                Sort = new SortBookDto { Field = SortBy, Direction = SortOrder }
            };

            IEnumerable<DataAccess.DataAccess.Book>? data = await _bookService.GetBookList(getBooksDto);
            List<DataAccess.DataAccess.Book>? books = data.ToList();
            int count = await _bookService.CountBookList(getBooksDto);
            if (books != null && books.Any()) {
                Book = books;
                TotalPages = (int)Math.Ceiling(decimal.Divide(count, PageSize));
            }
        }
    }
}
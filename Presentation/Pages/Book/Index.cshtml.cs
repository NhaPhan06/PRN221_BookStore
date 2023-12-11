using BusinessObject.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages.Book {
    public class IndexModel : PageModel {
        private readonly IBookService _bookService;

        public IndexModel(IBookService bookService) {
            _bookService = bookService;
        }

        public IList<DataAccess.DataAccess.Book> Book { get; set; } = default!;

        public async Task OnGetAsync() {
            IEnumerable<DataAccess.DataAccess.Book>? books = await _bookService.GetAll();
            if (books != null) {
                Book = books.ToList();
            }
        }
    }
}
using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages {
    public class BookDetails : PageModel {
        private readonly IBookService _bookService;

        public BookDetails(IBookService bookService) {
            _bookService = bookService;
        }

        [BindProperty] public DataAccess.DataAccess.Book Book { get; set; }

        public async Task OnGetAsync(string id) {
            DataAccess.DataAccess.Book? result = await _bookService.GetDetail(id);

            if (result == null) {
                RedirectToPage("/Error");
            }

            Book = result;
        }
    }
}
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Pages.Book {
    public class DetailsModel : PageModel {
        private readonly PRN_BookStoreContext _context;

        public DetailsModel(PRN_BookStoreContext context) {
            _context = context;
        }

        public DataAccess.DataAccess.Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id) {
            if (id == null || _context.Books == null) {
                return NotFound();
            }

            DataAccess.DataAccess.Book? book = await _context.Books.FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null) {
                return NotFound();
            }

            Book = book;
            return Page();
        }
    }
}
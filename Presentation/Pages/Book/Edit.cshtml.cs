using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Pages.Book {
    public class EditModel : PageModel {
        private readonly PRN_BookStoreContext _context;

        public EditModel(PRN_BookStoreContext context) {
            _context = context;
        }

        [BindProperty] public DataAccess.DataAccess.Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id) {
            if (id == null || _context.Books == null) {
                return NotFound();
            }

            DataAccess.DataAccess.Book? book = await _context.Books.FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null) {
                return NotFound();
            }

            Book = book;
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.Attach(Book).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!BookExists(Book.BookId)) {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(Guid id) {
            return (_context.Books?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
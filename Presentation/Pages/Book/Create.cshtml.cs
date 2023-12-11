using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Pages.Book {
    public class CreateModel : PageModel {
        private readonly PRN_BookStoreContext _context;

        public CreateModel(PRN_BookStoreContext context) {
            _context = context;
        }

        [BindProperty] public DataAccess.DataAccess.Book Book { get; set; } = default!;

        public IActionResult OnGet() {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid || _context.Books == null || Book == null) {
                return Page();
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
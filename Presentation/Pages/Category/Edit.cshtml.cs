using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Pages.Category {
    public class EditModel : PageModel {
        private readonly PRN_BookStoreContext _context;

        public EditModel(PRN_BookStoreContext context) {
            _context = context;
        }

        [BindProperty] public DataAccess.DataAccess.Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id) {
            if (id == null || _context.Categories == null) {
                return NotFound();
            }

            DataAccess.DataAccess.Category? category =
                await _context.Categories.FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null) {
                return NotFound();
            }

            Category = category;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.Attach(Category).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!CategoryExists(Category.CategoryId)) {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool CategoryExists(Guid id) {
            return (_context.Categories?.Any(e => e.CategoryId == id)).GetValueOrDefault();
        }
    }
}
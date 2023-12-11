using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Pages.Category {
    public class DeleteModel : PageModel {
        private readonly PRN_BookStoreContext _context;

        public DeleteModel(PRN_BookStoreContext context) {
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

        public async Task<IActionResult> OnPostAsync(Guid? id) {
            if (id == null || _context.Categories == null) {
                return NotFound();
            }

            DataAccess.DataAccess.Category? category = await _context.Categories.FindAsync(id);

            if (category != null) {
                Category = category;
                _context.Categories.Remove(Category);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Pages.Category {
    public class DetailsModel : PageModel {
        private readonly PRN_BookStoreContext _context;

        public DetailsModel(PRN_BookStoreContext context) {
            _context = context;
        }

        public DataAccess.DataAccess.Category Category { get; set; } = default!;

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
    }
}
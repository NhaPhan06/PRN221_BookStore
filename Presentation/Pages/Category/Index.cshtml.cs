using DataAccess;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Pages.Category {
    public class IndexModel : PageModel {
        private readonly PRN_BookStoreContext _context;

        public IndexModel(PRN_BookStoreContext context) {
            _context = context;
        }

        public IList<DataAccess.DataAccess.Category> Category { get; set; } = default!;

        public async Task OnGetAsync() {
            if (_context.Categories != null) {
                Category = await _context.Categories.ToListAsync();
            }
        }
    }
}
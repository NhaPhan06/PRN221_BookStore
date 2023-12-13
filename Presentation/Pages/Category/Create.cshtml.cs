using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages.Category {
    public class CreateModel : PageModel {
        private readonly PRN_BookStoreContext _context;

        public CreateModel(PRN_BookStoreContext context) {
            _context = context;
        }

        [BindProperty] public DataAccess.DataAccess.Category Category { get; set; } = default!;

        public IActionResult OnGet() {
            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid || _context.Categories == null || Category == null) {
                return Page();
            }

            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
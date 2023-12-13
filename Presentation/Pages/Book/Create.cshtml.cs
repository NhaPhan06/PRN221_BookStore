using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Pages.Book {
    public class CreateModel : PageModel {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;

        public CreateModel(IBookService bookService, ICategoryService categoryService) {
            _bookService = bookService;
            _categoryService = categoryService;
        }

        [BindProperty] public DataAccess.DataAccess.Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGet() {
            IEnumerable<DataAccess.DataAccess.Category> categoryList = await _categoryService.GetAll();

            ViewData["CategoryId"] = new SelectList(categoryList, "CategoryId", "Name");
            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync() {
            IEnumerable<DataAccess.DataAccess.Book>? bookList = await _bookService.GetAll();

            if (!ModelState.IsValid || bookList == null || Book == null) {
                return Page();
            }

            _bookService.Add(Book);

            return RedirectToPage("./Index");
        }
    }
}
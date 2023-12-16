using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLayer.Model;

namespace Presentation.Pages.Admin;

public class ProductManager : PageModel
{
    private IBookService _bookService;

    public ProductManager(IBookService bookService)
    {
        _bookService = bookService;
    }

    public List<Book> Books { get;set; } = default!;

    public async Task OnGetAsync()
    {
        var data = await _bookService.GetAll();
        Books = data;
    }
}
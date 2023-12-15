using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLayer.Model;

namespace Presentation.Pages;

public class Home : PageModel
{
    private readonly IBookService _bookService;

    public Home(IBookService bookService)
    {
        _bookService = bookService;
    }
    public List<Book> ListBook { get; set; }
    public void OnGet()
    {
        ListBook = _bookService.GetRandom3Books();
    }
    public IActionResult OnGetLogout()
    {
        HttpContext.Session.Remove("UserID");
        return RedirectToPage("./Home");
    }
}
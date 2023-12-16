using BusinessLayer.Service;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLayer.Model;
using Newtonsoft.Json;

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
    
    public async Task<IActionResult> OnPostAddToCart(Guid Id)
    {
        var check = false;
        List<Carts> cartsList = new();
        Carts newCart = new();
        var book = await _bookService.GetBookById(Id);

        // get cart from session
        var json = HttpContext.Session.GetString("cart");

        // deserialize cart
        if (json != null) cartsList = JsonConvert.DeserializeObject<List<Carts>>(json);

        // add book to cart
        if (cartsList.Count != 0)
        {
            foreach (var c in cartsList)
                if (c.BookId == book.BookId)
                {
                    c.StockQuantity += 1;
                    check = true;
                    break;
                }

            if (check == false)
            {
                newCart.BookId = book.BookId;
                newCart.StockQuantity = 1;
                newCart.Title = book.Title;
                newCart.Price = book.Price;
                newCart.ImageUrl = book.ImageUrl;
                cartsList.Add(newCart);
            }
        }
        else
        {
            newCart.BookId = book.BookId;
            newCart.StockQuantity = 1;
            newCart.Title = book.Title;
            newCart.Price = book.Price;
            newCart.ImageUrl = book.ImageUrl;
            cartsList.Add(newCart);
        }

        //Remove old Session
        HttpContext.Session.Remove("cart");

        // serialize cart
        json = JsonConvert.SerializeObject(cartsList);
        HttpContext.Session.SetString("cart", json);

        return  RedirectToPage();
    }
    
}
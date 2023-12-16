using BusinessLayer.Service;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLayer.Model;
using Newtonsoft.Json;

namespace Presentation.Pages;

public class BookDetails : PageModel
{
    private readonly IBookService _bookService;

    public BookDetails(IBookService bookService)
    {
        _bookService = bookService;
    }

    [BindProperty] public Book Book { get; set; } = default!;

    public async Task OnGetAsync(string id)
    {
        var result = await _bookService.GetDetail(id);

        if (result == null) RedirectToPage("/Error");

        Book = result;
    }

    public async Task<IActionResult> OnPostAddToCart(Guid Id, int quantity)
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
                    c.StockQuantity += quantity;
                    check = true;
                    break;
                }

            if (check == false)
            {
                newCart.BookId = book.BookId;
                newCart.StockQuantity = quantity;
                newCart.Title = book.Title;
                newCart.Price = book.Price;
                newCart.ImageUrl = book.ImageUrl;
                cartsList.Add(newCart);
            }
        }
        else
        {
            newCart.BookId = book.BookId;
            newCart.StockQuantity = quantity;
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

        return Redirect("shop");
    }
}
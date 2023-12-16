using BusinessLayer.Service;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLayer.Model;
using Newtonsoft.Json;

namespace Presentation.Pages;

public class Shop : PageModel
{
    private readonly IBookService _bookService;

    public Shop(IBookService bookService)
    {
        _bookService = bookService;
    }

    [BindProperty(SupportsGet = true)] public string Title { get; set; } = default!;

    [BindProperty(SupportsGet = true)] public string Category { get; set; } = default!;

    [BindProperty(SupportsGet = true)] public int CurrentPage { get; set; } = 1;

    [BindProperty(SupportsGet = true)] public int PageSize { get; set; } = 6;

    [BindProperty(SupportsGet = true)] public string SortBy { get; set; } = default!;

    [BindProperty(SupportsGet = true)] public string SortOrder { get; set; } = default!;

    public int TotalPages { get; set; }

    public IList<Book> Book { get; set; } = default!;

    public async Task OnGetAsync()
    {
        GetBooksDto getBooksDto = new()
        {
            Title = Title,
            Category = Category,
            CurrentPage = CurrentPage,
            PageSize = PageSize,
            Sort = new SortBookDto { Field = SortBy, Direction = SortOrder }
        };

        IEnumerable<Book>? data = await _bookService.GetBookList(getBooksDto);
        var books = data.ToList();
        var count = await _bookService.CountBookList(getBooksDto);
        if (books != null && books.Any())
        {
            Book = books;
            TotalPages = (int)Math.Ceiling(decimal.Divide(count, PageSize));
        }
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

        return  Page();
    }
}
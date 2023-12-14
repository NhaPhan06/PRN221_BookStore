using DataAccess.DataAccess;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Presentation.Pages;

public class CheckOut : PageModel
{

    [BindProperty] public User User { get; set; } = default!;
    [BindProperty] public Order receiver { get; set; } = default!;
    public IList<Carts> Carts { get; set; } = default!;
    
    [BindProperty] public decimal total { get; set; } = default;
    
    public void OnGet()
    {
        Carts = new List<Carts>();
        var jsoncart = HttpContext.Session.GetString("cart");
        if (jsoncart != null) Carts = JsonConvert.DeserializeObject<List<Carts>>(jsoncart);
        if (Carts.Count != 0)
        {
            foreach (var c in Carts)
            {
                total += c.Price * c.StockQuantity;
            }
        }
        else
        {
            total = 0;
        }
    }

    public async Task<IActionResult> OnPostDefault()
    {
        
        return RedirectToPage("Home");
    }
    
    public async Task<IActionResult> OnPostOther()
    {
        
        return RedirectToPage("Home");
    }
}
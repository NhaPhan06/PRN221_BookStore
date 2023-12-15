using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLayer.Model;

namespace Presentation.Pages.Admin;

public class ListOrder : PageModel
{
    private IOrderService _orderService;

    public ListOrder(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public IList<Order> Order { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync()
    {
        if (HttpContext.Session.GetString("AdminEmail") != null)
        {
            var data = _orderService.GetAll();
            Order = data;
            return Page();
        }
        else
        {
            HttpContext.Session.Remove("UserID");
            return RedirectToPage("../LoginPage");
        }
    }
}
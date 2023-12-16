using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLayer.Model;

namespace Presentation.Pages.Admin;

public class OrderManager : PageModel
{
    private IOrderService _orderService;

    public OrderManager(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public IList<Order> Order { get;set; } = default!;

    public async Task<IActionResult> OnGetAsync()
    {
        if (HttpContext.Session.GetString("AdminEmail") != null)
        {
            var data = _orderService.Get10Orders();
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
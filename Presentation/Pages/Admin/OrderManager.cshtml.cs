using BusinessLayer.Service;
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

    public async Task OnGetAsync()
    {
        var data = _orderService.Get10Orders();
        Order = data;
    }
}
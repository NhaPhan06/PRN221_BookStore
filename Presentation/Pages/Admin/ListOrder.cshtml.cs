using BusinessLayer.Service;
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
    public IList<Order> Order { get;set; } = default!;
    public async Task OnGetAsync()
    {
        var data = _orderService.GetAll();
        Order = data;
    }
}
using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLayer.Model;

namespace Presentation.Pages.Admin;

public class OrderDetailManager : PageModel
{
    private IOrderDetailService _orderDetailService;
    private IOrderService _orderService;

    public OrderDetailManager(IOrderDetailService orderDetailService, IOrderService orderService)
    {
        _orderService = orderService;
        _orderDetailService = orderDetailService;
    }
    public Order Order { get;set; } = default!;
    public IList<OrderDetail> OrderDetails { get;set; } = default!;

    public async Task OnGetAsync(Guid id)
    {
        var data = _orderDetailService.GetOrderDetailByOrderId(id);
        OrderDetails = data;
        Order = _orderService.GetOrderById(id);
    }
    
    public async Task<IActionResult> OnPostConfirmAsync(Guid id)
    {
        return Page();
    }

    public async Task<IActionResult> OnPostCancelAsync(Guid id)
    {
        return Page();
    }
}
using BusinessLayer.Service;
using DataAccess.Enum;
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

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        if (HttpContext.Session.GetString("AdminEmail") != null)
        {
            var data = _orderDetailService.GetOrderDetailByOrderId(id);
            OrderDetails = data;
            Order = _orderService.GetOrderById(id);
            return Page();
        }
        else
        {
            HttpContext.Session.Remove("UserID");
            return RedirectToPage("../LoginPage");
        }
    }
    
    public async Task<IActionResult> OnPostConfirmAsync(Guid id)
    {
        
        Order = _orderService.ConfirmOrder(id);
        var data = _orderDetailService.GetOrderDetailByOrderId(id);
        OrderDetails = data;
        Order = _orderService.GetOrderById(id);
        return Page();
    }

    public async Task<IActionResult> OnPostCancelAsync(Guid id)
    {
        Order = _orderService.DisableOrder(id);
        var data = _orderDetailService.GetOrderDetailByOrderId(id);
        OrderDetails = data;
        Order = _orderService.GetOrderById(id);
        return Page();
    }
}
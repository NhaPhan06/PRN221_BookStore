using BusinessLayer.Service;
using BusinessLayer.Service.Implement;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages.Orders
{
    public class OrderListcshtmlModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;

        public OrderListcshtmlModel(IOrderService orderService, IOrderDetailService orderDetailService)
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }
        public List<Order> orders { get; set; } = default!;
        public Order Order { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public void OnGet()
        {
            orders = _orderService.GetAll();
        }
        public IActionResult OnGetDisable(Guid id)
        {
            _orderService.DisableOrder(id);          
            return RedirectToPage("OrderListcshtml");
        }
        public IActionResult OnGetRecive(Guid id)
        {
            _orderService.ReciveOrder(id);
            return RedirectToPage("OrderListcshtml");
        } 
        public IActionResult OnGetPending(Guid id)
        {
            _orderService.PendingOrder(id);
            return RedirectToPage("OrderListcshtml");
        }
        public IActionResult OnGetConfirm(Guid id)
        {
            _orderService.ConfirmOrder(id);
            return RedirectToPage("OrderListcshtml");
        }


    }
}

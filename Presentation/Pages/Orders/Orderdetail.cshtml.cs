using BusinessLayer.Service;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages.Orders
{
    public class OrderdetailModel : PageModel
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IOrderService _orderService;
        public OrderdetailModel(IOrderDetailService orderDetailService, IOrderService orderService)
        {
            _orderDetailService = orderDetailService;
            _orderService = orderService;
        }
        public List<OrderDetail> Orderdetails { get; set; }
        public IActionResult OnGet(Guid id)
        {
            var order = _orderService.GetOrderById(id);
            Orderdetails = _orderDetailService.GetAllOrderDetailByOrderId(order.OrderId);
            return Page();
        }
    }
}

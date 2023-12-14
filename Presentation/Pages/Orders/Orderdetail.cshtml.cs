using BusinessLayer.Service;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages.Orders
{
    public class OrderdetailModel : PageModel
    {
        private  readonly IOrderDetailService _orderDetailService;
        private readonly IOrderService _orderService;
        public OrderdetailModel(IOrderDetailService orderDetailService, IOrderService orderService)
        {
            _orderDetailService = orderDetailService;
            _orderService = orderService;
        }
        public  OrderDetail Orderdetail { get; set; }
        public  Order Order { get; set; }

        public IActionResult OnGet(Guid id)
        {
            var orderdetail = _orderService.GetOrderById(id);
            Order = orderdetail;
            return Page();
        }
    }
}

using BusinessLayer.Service;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages.Orders {
    public class OrderListcshtmlModel : PageModel {
        private readonly IOrderService _orderService;

        public OrderListcshtmlModel(IOrderService orderService) {
            _orderService = orderService;
        }

        public List<Order> orders { get; set; } = default!;
        public Order Order { get; set; }

        public void OnGet() {
            orders = _orderService.GetAll();
        }

        public IActionResult OnGetDisable(Guid id) {
            _orderService.DisableOrder(id);
            return RedirectToPage("OrderListcshtml");
        }

        public IActionResult OnGetRecive(Guid id) {
            _orderService.ReciveOrder(id);
            return RedirectToPage("OrderListcshtml");
        }

        public IActionResult OnGetDelivery(Guid id) {
            _orderService.DeliveryOrder(id);
            return RedirectToPage("OrderListcshtml");
        }

        public IActionResult OnGetConfirm(Guid id) {
            _orderService.ConfirmOrder(id);
            return RedirectToPage("OrderListcshtml");
        }
    }
}
using BusinessLayer.Service;
using DataAccess.DataAccess;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Presentation.Pages {


    public class CheckOut : PageModel {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;

        public CheckOut(IUserService userService, IOrderService orderService) {
            _orderService = orderService;
            _userService = userService;
        }

        [BindProperty] public User User { get; set; } = default!;
        [BindProperty] public Order receiver { get; set; } = default!;
        public List<Carts> Carts { get; set; } = default!;

        [BindProperty] public decimal total { get; set; } = default;

        public void OnGet() {
            //Show User Default
            var userId = HttpContext.Session.GetString("UserID");
            if (userId != null) {
                User = _userService.GetUserById(Guid.Parse(userId));
            }

            // Show cart
            Carts = new List<Carts>();
            var jsoncart = HttpContext.Session.GetString("cart");
            if (jsoncart != null) Carts = JsonConvert.DeserializeObject<List<Carts>>(jsoncart);
            if (Carts.Count != 0) {
                foreach (var c in Carts) {
                    total += c.Price * c.StockQuantity;
                }
            }


        }

        public async Task<IActionResult> OnPostDefault() {
            //create order
            var order = new Order();
            var userId = HttpContext.Session.GetString("UserID");
            var user = _userService.GetUserById(Guid.Parse(userId));
            order.OrderId = Guid.NewGuid();
            order.UserId = user.UserId;
            order.Address = user.Address;
            order.PhoneNumber = user.PhoneNumber;
            order.ReceiverName = user.Firstname + user.Lastname;

            //get cart
            var jsoncart = HttpContext.Session.GetString("cart");
            Carts = JsonConvert.DeserializeObject<List<Carts>>(jsoncart);
            await _orderService.CreateOrder(Carts, order);

            return RedirectToPage("Home");
        }

        public async Task<IActionResult> OnPostOther() {

            return RedirectToPage("Home");
        }
    }
}
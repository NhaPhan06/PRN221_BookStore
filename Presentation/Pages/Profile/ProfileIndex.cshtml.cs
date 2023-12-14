using BusinessLayer.Service;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages.Profile {
    public class ProfileIndexModel : PageModel {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public ProfileIndexModel(IUserService userService, IOrderService orderService) {
            _userService = userService;
            _orderService = orderService;
        }

        [BindProperty] public User Users { get; set; }

        public List<Order> orders { get; set; } = default!;

        public IActionResult OnGet() {
            string? accId = HttpContext.Session.GetString("UserID");
            if (accId == null) {
                return RedirectToPage("/LoginPage");
            }

            Guid id = new(accId);
            Users = _userService.GetUserById(id);
            if (Users.UserId != id) {
                return RedirectToPage("/LoginPage");
            }

            orders = _orderService.GetOrdersByUserId(Users.UserId);
            return Page();
        }

        public IActionResult OnPost() {
            string? accId = HttpContext.Session.GetString("UserID");
            Guid id = new(accId);
            try {
                Users = _userService.UpdateUser(id, Users);
                if (Users == null) {
                    throw new Exception();
                }

                return RedirectToPage("/Profile/ProfileIndex");
            } catch (Exception ex) {
                ViewData["notification"] = ex.Message;
            }

            return Page();
        }
    }
}
using BusinessLayer.Service;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Principal;

namespace Presentation.Pages.Profile
{
    public class ProfileIndexModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        public ProfileIndexModel(IUserService userService, IOrderService orderService, IOrderDetailService orderDetailService)
        {
            _userService = userService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }

        [BindProperty]
        public User Users { get; set; } = default!;
        public List<Order> orders { get; set; } = default!;
        [BindProperty]
        public string OrderId { get; set; }
        public List<OrderDetail> OrderDetail { get; set; } = default!;
        public IActionResult OnGet()
        {
            var accId = HttpContext.Session.GetString("UserID");
            if(accId == null)
            {
                return RedirectToPage("/LoginPage");
            }
            else
            {
                Guid id = new Guid(accId);
                Users = _userService.GetUserById(id);
                OrderDetail = new List<OrderDetail>();
                if (Users.UserId != id)
                {
                    return RedirectToPage("/LoginPage");
                }
                else
                {
                    orders = _orderService.GetOrdersByUserId(Users.UserId);
                    return Page();
                }
            }         
        }
        public IActionResult OnPost()
        {
            var accId = HttpContext.Session.GetString("UserID");
            Guid id = new Guid(accId);
            try
            {
                Users = _userService.UpdateUser(id,Users);
                if(Users == null)
                {
                    throw new Exception();
                }
                return RedirectToPage("/Profile/ProfileIndex");
            }catch (Exception ex)
            {
                ViewData["notification"] = ex.Message.ToString();
            }
            return Page();
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("UserID");
            return RedirectToPage("/Home");
        }
        public IActionResult OnGetOrderDetails() {
            var orId = Guid.Parse(OrderId);
            OrderDetail = _orderDetailService.GetOrderDetailByOrderId(orId);
            return Page();
        }
    }
}

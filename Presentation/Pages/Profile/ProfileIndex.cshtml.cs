using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLayer.Model;

namespace Presentation.Pages.Profile;

public class ProfileIndexModel : PageModel
{
    private readonly IOrderDetailService _orderDetailService;
    private readonly IOrderService _orderService;
    private readonly IUserService _userService;

    public ProfileIndexModel(IUserService userService, IOrderService orderService,
        IOrderDetailService orderDetailService)
    {
        _userService = userService;
        _orderService = orderService;
        _orderDetailService = orderDetailService;
    }

    [BindProperty] public User Users { get; set; } = default!;

    public List<Order> orders { get; set; } = default!;

    [BindProperty] public string OrderId { get; set; }

    public List<OrderDetail> OrderDetail { get; set; } = default!;

    public IActionResult OnGet()
    {
        var accId = HttpContext.Session.GetString("UserID");
        if (accId == null) return RedirectToPage("/LoginPage");

        Guid id = new(accId);
        Users = _userService.GetUserById(id);
        OrderDetail = new List<OrderDetail>();
        if (Users.UserId != id) return RedirectToPage("/LoginPage");

        orders = _orderService.GetOrdersByUserId(Users.UserId);
        return Page();
    }

    public void OnPost()
    {
        var accId = HttpContext.Session.GetString("UserID");
        Guid id = new(accId);
        try
        {

            orders = _orderService.GetOrdersByUserId(Users.UserId);
            OrderDetail = new List<OrderDetail>();
            Users = _userService.UpdateUser(id, Users);
            if (Users == null) throw new Exception();
            else
            ViewData["notification"] = "Update Successfully!";
            /*return Page();*/
        }
        catch (Exception ex)
        {
            ViewData["notification"] = ex.Message;
        }

        /*return Page();*/
    }

    public IActionResult OnGetLogout()
    {
        HttpContext.Session.Remove("UserID");
        return RedirectToPage("/Home");
    }

    public IActionResult OnGetOrderDetails(string id)
    {
        var accId = HttpContext.Session.GetString("UserID");
        Guid userid = new(accId);
        Users = _userService.GetUserById(userid);
        orders = _orderService.GetOrdersByUserId(Users.UserId);
        var orId = Guid.Parse(id);
        OrderDetail = _orderDetailService.GetOrderDetailByOrderId(orId);
        return Page();
    }

    public IActionResult OnGetCancelOrders(string id)
    {
        var accId = HttpContext.Session.GetString("UserID");
        Guid userid = new(accId);
        var orId = Guid.Parse(id);
        Users = _userService.GetUserById(userid);

        _orderService.DisableOrder(orId);
        orders = _orderService.GetOrdersByUserId(Users.UserId);

        OrderDetail = _orderDetailService.GetOrderDetailByOrderId(orId);
        return Page();
    }
}
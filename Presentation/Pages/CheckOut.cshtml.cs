using BusinessLayer.Service;
using DataAccess.Enum;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLayer.Model;
using Newtonsoft.Json;

namespace Presentation.Pages;

public class CheckOut : PageModel
{
    private readonly IOrderService _orderService;
    private readonly IUserService _userService;

    public CheckOut(IUserService userService, IOrderService orderService)
    {
        _orderService = orderService;
        _userService = userService;
    }

    [BindProperty] public User User { get; set; } = default!;
    [BindProperty] public Order receiver { get; set; } = default!;
    public List<Carts> Carts { get; set; } = default!;

    [BindProperty] public decimal Total { get; set; }

    public void OnGet()
    {
        //Show User Default
        var userId = HttpContext.Session.GetString("UserID");
        if (userId != null) User = _userService.GetUserById(Guid.Parse(userId));

        // Show cart
        Carts = new List<Carts>();
        var jsoncart = HttpContext.Session.GetString("cart");
        if (jsoncart != null) Carts = JsonConvert.DeserializeObject<List<Carts>>(jsoncart);
        if (Carts.Count != 0)
            foreach (var c in Carts)
                Total += c.Price * c.StockQuantity;
    }

    public async Task<IActionResult> OnPostDefault()
    {
        //create order
        var order = new Order();
        var userId = HttpContext.Session.GetString("UserID");
        var user = _userService.GetUserById(Guid.Parse(userId));
        order.OrderId = Guid.NewGuid();
        order.UserId = user.UserId;
        order.Address = user.Address;
        order.PhoneNumber = user.PhoneNumber;
        order.ReceiverName = user.Firstname + user.Lastname;
        order.PaymentMethod = receiver.PaymentMethod;
        order.UpdatedAt = DateTime.Now;
        order.Status = OrderStatus.PENDING.ToString();

        //get cart
        var jsoncart = HttpContext.Session.GetString("cart");
        Carts = JsonConvert.DeserializeObject<List<Carts>>(jsoncart);
        await _orderService.CreateOrder(Carts, order);

        //delete cart
        HttpContext.Session.Remove("cart");

        return RedirectToPage("shop");
    }

    public async Task<IActionResult> OnPostOther()
    {
        //create order
        var order = new Order();
        var userId = HttpContext.Session.GetString("UserID");
        var user = _userService.GetUserById(Guid.Parse(userId));
        order.OrderId = Guid.NewGuid();
        order.UserId = user.UserId;
        order.Address = receiver.Address;
        order.PhoneNumber = receiver.PhoneNumber;
        order.ReceiverName = receiver.ReceiverName;
        order.PaymentMethod = receiver.PaymentMethod;
        //get cart
        var jsoncart = HttpContext.Session.GetString("cart");
        Carts = JsonConvert.DeserializeObject<List<Carts>>(jsoncart);
        await _orderService.CreateOrder(Carts, order);

        //delete cart
        HttpContext.Session.Remove("cart");

        return RedirectToPage("shop");
    }

    public async Task<IActionResult> OnPostCancel()
    {
        //delete cart
        HttpContext.Session.Remove("cart");
        return RedirectToPage("shop");
    }
}
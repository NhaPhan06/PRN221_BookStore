using BusinessLayer.Service;
using DataAccess.DTOS.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Principal;

namespace Presentation.Pages;

public class LoginPageModel : PageModel
{
    private readonly IUserService _userService;

    public LoginPageModel(IUserService userService)
    {
        _userService = userService;
    }

    [BindProperty] public string Username { get; set; }

    [BindProperty] public string Password { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        AuthenticationResult result = _userService.LoginCheckRole(Username, Password);
        if(result.IsAuthenticated)
        {
            if(result.Role == UserRole.Admin)
            {
                HttpContext.Session.SetString("AdminEmail",result.Email);
                return RedirectToPage("/Admin/User");
            }
            else if(result.Role == UserRole.Customer)
            {
                var account = _userService.Login(Username, Password);
                if (account == null)
                {
                    ViewData["notification"] = "Account does not exist!";
                    return Page();
                }

                if (account.Status.ToUpper() == "INACTIVE")
                {
                    ViewData["notification"] = "Your account is banned!";
                    return Page();
                }
                HttpContext.Session.SetString("UserID", account.UserId.ToString());
                HttpContext.Session.SetString("UserName", account.Username);
                return RedirectToPage("/Home");
            }
        }
        else
        {
            ViewData["notification"] = "Account does not exist!";
            return Page();
        }
        /*try
        {
            var account = _userService.Login(Username, Password);
            var admin = _userService.GetAdminAccount(Username, Password);
            if(admin == true)
            {
                return RedirectToPage("/Admin/User");
            }
            else if (account == null)
            {
                ViewData["notification"] = "Account does not exist!";
                return Page();
            }

            if (account.Status.ToUpper() == "INACTIVE")
            {
                ViewData["notification"] = "Your account is banned!";
                return Page();
            }

            HttpContext.Session.SetString("UserID", account.UserId.ToString());
            HttpContext.Session.SetString("UserName", account.Username);
            return RedirectToPage("/Home");
        }
        catch (Exception ex)
        {
            ViewData["notification"] = ex.Message;
        }*/

        return Page();
    }
}
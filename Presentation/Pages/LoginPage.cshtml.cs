using BusinessLayer.Service;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages
{
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
            try
            {
                User? account = _userService.Login(Username, Password);
                if (account == null)
                {
                    ViewData["notification"] = "Account does not exist!";
                    return Page();
                }

                if (account.Status.ToUpper().ToString() == "INACTIVE")
                {
                    ViewData["notification"] = "Your account is banned!";
                    return Page();
                }

                HttpContext.Session.SetString("UserID", account.UserId.ToString());
                HttpContext.Session.SetString("UserName",account.Username);
                return RedirectToPage("/Home");
            }
            catch (Exception ex)
            {
                ViewData["notification"] = ex.Message;
            }

            return Page();
        }
    }
}
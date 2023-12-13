using BusinessLayer.Service;
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
                var account = _userService.Login(Username, Password);
                if (account == null)
                {
                    ViewData["notification"] = "Tài khoản không tồn tại";
                    return RedirectToPage();
                }

                if (account.Status == "INACTIVE")
                {
                    ViewData["notification"] = "Tài khoản đã khóa";
                    return Page();
                }
                else
                {
                    return RedirectToPage("/Home");
                }
            }
            catch (Exception ex)
            {
                ViewData["notification"] = ex.Message;
            }
            return Page();
        }
    }
}

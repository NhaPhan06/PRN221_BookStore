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

        public ProfileIndexModel(IUserService userService)
        {
            _userService = userService;
        }
        [BindProperty]
        public User Users { get; set; } = default;
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
                if (Users.UserId != id)
                {
                    return RedirectToPage("/LoginPage");
                }
                else
                {
                    Users = _userService.GetUserById(id);
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
    }
}

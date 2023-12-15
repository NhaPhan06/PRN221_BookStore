using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages.Admin {
    public class UserModel : PageModel {
        private IUserService _userService;

        public UserModel(IUserService userService) {
            _userService = userService;
        }

        public IList<ModelLayer.Model.User> Users { get; set; } = new List<ModelLayer.Model.User>();

        public async Task<IActionResult> OnGetAsync() {
            if (HttpContext.Session.GetString("AdminEmail") != null)
            {
                var data = await _userService.GetAll();
                Users = data;
                return Page();
            }
            else
            {
                HttpContext.Session.Remove("UserID");
                return RedirectToPage("../LoginPage");
            }
        }

        public Task<IActionResult> OnGetBan(Guid guid) {
            _userService.BanUser(guid);
            return Task.FromResult<IActionResult>(RedirectToPage("./User"));
        }

        public Task<IActionResult> OnGetUnban(Guid guid) {
            _userService.UnbanUser(guid);
            return Task.FromResult<IActionResult>(RedirectToPage("./User"));
        }
        
        
    }
}
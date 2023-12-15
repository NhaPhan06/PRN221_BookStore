using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLayer.Model;

namespace Presentation.Pages.Admin {
    public class UserDetail : PageModel {
        
    private readonly IUserService _userService;

    public UserDetail(IUserService userService) {
        _userService = userService;
        
    }
    
    [BindProperty(SupportsGet = true)]
    public User User { get; set; }
        public void OnGet(Guid guid) {
            var data = _userService.GetUserById(guid);
            User = data;
        }
    }
}
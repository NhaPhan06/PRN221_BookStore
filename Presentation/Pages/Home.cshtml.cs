using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages {
    public class Home : PageModel {
        public IActionResult OnGetLogout() 
        {
            HttpContext.Session.Remove("UserID");
            return RedirectToPage("./Home");
        }
    }
}
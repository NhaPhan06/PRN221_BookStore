using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages;

public class CheckOut : PageModel
{

    [BindProperty] private User User { get; set; } = default!;
    
    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPostDefault()
    {
        
        
        
        return RedirectToPage("Home");
    }
    
    public async Task<IActionResult> OnPostOther()
    {
        
        
        
        return RedirectToPage("Home");
    }
}
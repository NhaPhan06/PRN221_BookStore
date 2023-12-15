using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLayer.Model;

namespace Presentation.Pages.Admin;

public class Index : PageModel
{
    private IUserService _userService;

    public Index(IUserService userService)
    {
        _userService = userService;
    }

    public IList<User> Users { get; set; } = new List<User>();

    public async Task OnGetAsync()
    {
        var data = await _userService.GetAll();
        Users = data;
    }
}
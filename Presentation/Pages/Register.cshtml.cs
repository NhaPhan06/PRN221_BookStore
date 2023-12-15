//using BusinessLayer.DTOS.User;

using BusinessLayer.Service;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages;

public class RegisterModel : PageModel
{
    private readonly IUserService _userService;

    public RegisterModel(IUserService userService)
    {
        _userService = userService;
    }

    [BindProperty] public CreateUser CreateUser { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }

    public IActionResult OnPost()
    {
        try
        {
            if (_userService.CheckEmailUsername(CreateUser.Email, CreateUser.Username) != null)
                throw new Exception("Email đã được sử dụng. Vui lòng nhập lại!");

            if (CreateUser.Birthdate >= DateTime.Now || CreateUser.Birthdate < DateTime.Parse("1940-01-01"))
                throw new Exception("Ngày sinh không hợp lệ. Vui lòng nhập lại!");

            _userService.CreateUser(CreateUser);
            return RedirectToPage("/LoginPage");
        }
        catch (Exception ex)
        {
            ViewData["notification"] = ex.Message;
        }

        return Page();
    }
}
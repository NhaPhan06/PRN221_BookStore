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
            if (_userService.CheckUsername(CreateUser.Username) != null)
                throw new Exception("Username is used. Please re-enter!");
            if (_userService.CheckEmail(CreateUser.Email) != null)
                throw new Exception("Email is used. Please re-enter!");

            

            if (CreateUser.Birthdate >= DateTime.Parse("2014-01-01") || CreateUser.Birthdate < DateTime.Parse("1940-01-01"))
                throw new Exception("Invalid Date (from 2014-01-01 to 1940-01-01!");

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
namespace BussinessObject.Model.Request;

public class CreateUser
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? Birthdate { get; set; }
}
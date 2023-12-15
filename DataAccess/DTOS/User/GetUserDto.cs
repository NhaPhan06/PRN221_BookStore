namespace DataAccess.Model {
    public class GetUserDto {
        public string? Username { get; set; }
        public string SortField { get; set; } 
        public string SortDirection { get; set; }
    }

    public struct UserSortField {
        public const string Username = "Username";
        public const string Email = "Email";
        public const string Status = "Status";
        public const string Birthdate = "Birthdate";
    } 
}
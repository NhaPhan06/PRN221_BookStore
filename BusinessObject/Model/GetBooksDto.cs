namespace BusinessObject.Model {
    public class GetBooksDto {
        public string? Title { get; set; }
        public string? Category { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public SortBookDto Sort { get; set; } = new();
    }

    public class SortBookDto {
        public string? Field { get; set; }
        public string? Direction { get; set; }
    }

    public struct SortDirection {
        public const string Asc = "asc";
        public const string Desc = "desc";
    }

    public struct SortField {
        public const string Title = "Title";
        public const string Category = "Category";
        public const string Status = "Status";
        public const string Date = "Date";
        public const string Price = "Price";
        public const string Stock = "Stock";
    }

    public struct Status {
        public const string Active = "Active";
        public const string Inactive = "Inactive";
    }

    public struct BookCategory {
        public const string Programming = "Programming";
        public const string Science = "Science";
        public const string Engineering = "Engineering";
        public const string Literature = "Literature";
        public const string SelfHelp = "Self-help";
    }
}
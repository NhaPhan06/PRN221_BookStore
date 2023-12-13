namespace DataAccess.Model;

public class Carts
{
    public Guid BookId { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string? ImageUrl { get; set; }
}
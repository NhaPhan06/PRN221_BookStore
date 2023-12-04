using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class Book
    {
        public Book()
        {
            CartItems = new HashSet<CartItem>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string? Isbn { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

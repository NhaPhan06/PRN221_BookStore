using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class CartItem
    {
        public Guid CartItemId { get; set; }
        public Guid CartId { get; set; }
        public Guid BookId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual ShoppingCart Cart { get; set; } = null!;
    }
}

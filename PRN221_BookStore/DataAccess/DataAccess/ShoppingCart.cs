using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int CartId { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}

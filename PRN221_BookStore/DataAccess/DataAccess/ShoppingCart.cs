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

        public Guid CartId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}

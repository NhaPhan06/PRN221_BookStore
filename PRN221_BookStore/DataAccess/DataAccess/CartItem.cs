﻿using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class CartItem
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual ShoppingCart Cart { get; set; } = null!;
    }
}

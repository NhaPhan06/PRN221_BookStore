using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            ShoppingCarts = new HashSet<ShoppingCart>();
            UserDetails = new HashSet<UserDetail>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public virtual ICollection<UserDetail> UserDetails { get; set; }
    }
}

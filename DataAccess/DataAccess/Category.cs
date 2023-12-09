﻿using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        public Guid CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}

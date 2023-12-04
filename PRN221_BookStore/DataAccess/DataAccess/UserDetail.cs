﻿using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class UserDetail
    {
        public int UserDetailId { get; set; }
        public int UserId { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthdate { get; set; }

        public virtual User User { get; set; } = null!;
    }
}

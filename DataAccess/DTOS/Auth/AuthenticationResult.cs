using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOS.Auth
{
    public class AuthenticationResult
    {
        public bool IsAuthenticated { get; set; }
        public UserRole Role { get; set; }
        public string Email { get; set; }
    }
}

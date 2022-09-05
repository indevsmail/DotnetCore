using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookiAuthCrud.Models
{
    public class AuthenticateUserRequest
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}

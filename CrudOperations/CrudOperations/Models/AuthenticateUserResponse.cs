using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperations.Models
{
    public class AuthenticateUserResponse : ResponseBase
    {
        public UserDetail UserData { get; set; }
        public string Token { get; set; }
    }
}

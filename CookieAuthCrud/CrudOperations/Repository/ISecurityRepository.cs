using CookiAuthCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookiAuthCrud.Repository
{
    public interface ISecurityRepository
    {
        public AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest request);
    }
}

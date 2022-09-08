using CrudOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperations.Services
{
    public interface ISecurityService
    {
        public AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest request);

    }
}

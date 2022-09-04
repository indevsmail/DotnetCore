using CrudOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperations.Repository
{
    public interface ISecurityRepository
    {
        public AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest request);
    }
}

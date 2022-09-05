using CookiAuthCrud.Models;
using CookiAuthCrud.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookiAuthCrud.Services
{
    public class SecurityService :ISecurityService
    {
        private readonly ISecurityRepository _securityRepository;
        public SecurityService(ISecurityRepository securityRepository)
        {
            _securityRepository = securityRepository;
        }
        public AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest request)
        {
            return _securityRepository.AuthenticateUser(request);
        }
    }
}

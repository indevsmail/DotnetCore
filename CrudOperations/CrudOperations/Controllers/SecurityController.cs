using CrudOperations.Models;
using CrudOperations.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }
        [HttpPost]
        [Route("AuthenticateUser")]
        public IActionResult AuthenticateUser(AuthenticateUserRequest request)
        {
            AuthenticateUserResponse response = null;
            try
            {
                response = _securityService.AuthenticateUser(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
            }
            return response.IsSuccess ? Ok(response) : (IActionResult)NotFound(response);
        }
    }
}

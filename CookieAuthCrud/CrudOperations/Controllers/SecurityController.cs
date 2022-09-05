using CookiAuthCrud.Models;
using CookiAuthCrud.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookiAuthCrud.Controllers
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
        public async Task<IActionResult> AuthenticateUser(AuthenticateUserRequest request)
        {
            AuthenticateUserResponse response = null;
            try
            {
                response = _securityService.AuthenticateUser(request);
                if(response.IsSuccess)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, response.UserData.Name.ToString()),
                        new Claim(ClaimTypes.PrimarySid, response.UserData.UserId),
                        new Claim(ClaimTypes.Role, response.UserData.Role.ToString())
                    };
                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions
                        .SignInAsync(HttpContext, CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));
                }
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

using CookiAuthCrud.Models;
using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CookiAuthCrud.Repository
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly IConfiguration _configuration;
        //private const SecurityKey = ""
        public SecurityRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest request)
        {
            List<UserDetail> users = new List<UserDetail>()
                {
                    new UserDetail(){UserId="devdhingra", Password="password", Name="Dev Dhingra", Role="Admin", Email="dev@dev.com"},
                    new UserDetail(){UserId="sammark", Password="password", Name="Sam Mark", Role="User", Email="sam@mark.com"}
                };
            AuthenticateUserResponse response = new AuthenticateUserResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try 
            {
                response.UserData = users.SingleOrDefault(x => 
                    x.UserId == request.UserId.ToString() && 
                    x.Password == request.Password.ToString());

                //response.Token = GenerateJwtToken(response.UserData.UserId, response.UserData.Name, response.UserData.Role);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message; 
            }
            return response;
        }
    }
}

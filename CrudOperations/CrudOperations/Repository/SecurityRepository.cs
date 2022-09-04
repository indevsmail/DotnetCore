using CrudOperations.Models;
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

namespace CrudOperations.Repository
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

                response.Token = GenerateJwtToken(response.UserData.UserId, response.UserData.Name, response.UserData.Role);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message; 
            }
            return response;
        }
        private string GenerateJwtToken(string userId, string userName, string role)
        {
            //1) Create SecurityKey by SymetricSecurityKey passing encoded jwt key from appSettings.
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            //2) Created SigningCredential by passing above SecurityKey & HmacSha256 algorithm.
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //3) Created Claims array of type JwtRegisteredClaimNames 
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sid,userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, userName.ToString()),
                new Claim(ClaimTypes.Role,role.ToString()),
                new Claim("Date", DateTime.Now.ToString())
            };

            //4) Create Token by JwtSecurityToken passing Issuer, Audience, Claims, Expire time, above SigningCredentials.
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"].ToString(),
                _configuration["Jwt:Audience"].ToString(),
                claims, expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credential);

            //5) Serializes above JwtSecurityToken by JwtSecurityTokenHandler to pass to client.
            string tokenData = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenData;
        }
    }
}

using APIAuthentication.BL.Interfaces;
using APIAuthentication.BusinessEntities.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APIAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserManager userManager;

        public LoginController(IConfiguration configuration, IUserManager userManager)
        {
            this._configuration = configuration;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Login(UserRequestModel user)
        {
            IActionResult response = Unauthorized();
            bool isValid = await CheckUserAuthetication(user);
            if (isValid)
            {
                string token = GenerateToken(user);
                response = Ok(new { token = token });
            }
            return response;
        }

        private async Task<bool> CheckUserAuthetication(UserRequestModel user)
        {
            return await this.userManager.CheckUserCredentials(user);
        }

        private string GenerateToken(UserRequestModel user)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("Role", user.Role.ToString())
            };
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

using APIAuthentication.Context;
using APIAuthentication.Models;
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
        private UserDbContext context;

        public LoginController(IConfiguration configuration, UserDbContext context)
        {
            this._configuration = configuration;
            this.context = context;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Login(User user)
        {
            IActionResult response = Unauthorized();
            User authenticatedUser = await CheckUserAuthetication(user);
            if (authenticatedUser != null)
            {
                string token = GenerateToken(user);
                response = Ok(new { token = token });
            }
            return response;
        }

        private async Task<User> CheckUserAuthetication(User user)
        {
            User userEntity = await Task.Run(() => context.Users.Where(x => x.Role == user.Role && x.Email == user.Email && x.Password == user.Password).FirstOrDefault());
            return userEntity;
        }

        private string GenerateToken(User user)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("Role",user.Role.ToString())
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

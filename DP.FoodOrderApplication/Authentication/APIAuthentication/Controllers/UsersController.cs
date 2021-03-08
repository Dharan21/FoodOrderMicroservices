using APIAuthentication.Context;
using APIAuthentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserDbContext context;
        public UsersController(UserDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(User user)
        {
            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();
            return Ok();
        }
    }
}

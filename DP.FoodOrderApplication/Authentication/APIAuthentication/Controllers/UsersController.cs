using APIAuthentication.Context;
using APIAuthentication.Models;
using Infrastructure.Common.Constants;
using Infrastructure.Common.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Infrastructure.Common.Enumerators.Enumerators;

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
        private async Task<IActionResult> AddUser(User user)
        {
            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();
            return Ok();
        }
    }
}

using APIAuthentication.BL.Interfaces;
using APIAuthentication.BusinessEntities.RequestModel;
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
        private readonly IUserManager userManager;

        public UsersController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("Add")]
        private async Task<IActionResult> Add(UserRequestModel user)
        {
            await userManager.Add(user);
            return Ok();
        }
    }
}

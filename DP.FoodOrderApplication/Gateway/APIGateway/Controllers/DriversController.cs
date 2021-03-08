using APIGateway.Models;
using Infrastructure.Common.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Controllers
{
    public class DriversController : ControllerBase
    {
        private IConfiguration Configuration;
        public DriversController(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit(Driver driver)
        {
            string EditDriverUri = $"${Configuration["DriverServiceEndpoint"]}/Drivers/Edit";
            await HttpRequestClient.PutRequest<object>(EditDriverUri, driver);

            string EditDriverForOrderMicroserviceUri = $"${Configuration["OrderServiceEndpoint"]}/Drivers/Edit";
            await HttpRequestClient.PutRequest<object>(EditDriverForOrderMicroserviceUri, driver);

            return Ok();
        }

        [HttpPut]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int driverId)
        {
            string DeleteDriverUri = $"${Configuration["DriverServiceEndpoint"]}/Drivers/Delete/${driverId}";
            await HttpRequestClient.DeleteRequest<object>(DeleteDriverUri);

            string DeleteDriverForOrderMicroserviceUri = $"${Configuration["OrderServiceEndpoint"]}/Drivers/Delete/${driverId}";
            await HttpRequestClient.DeleteRequest<object>(DeleteDriverForOrderMicroserviceUri);

            return Ok();
        }
    }
}

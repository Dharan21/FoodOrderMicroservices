using Microsoft.AspNetCore.Mvc;
using OrderServices.BL.Interfaces;
using OrderServices.BusinessEntities.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServices.Controllers
{
    public class DriversController : ControllerBase
    {
        private IDriverManager driverManager;
        public DriversController(IDriverManager driverManager)
        {
            this.driverManager = driverManager;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(DriverRequestModel driver)
        {
            await this.driverManager.Create(driver);
            return Ok();
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(DriverRequestModel driver)
        {
            await this.driverManager.Edit(driver);
            return Ok();
        }

        [HttpPost]
        [Route("Delete/{restaurantId}")]
        public async Task<IActionResult> Delete(int driverId)
        {
            await this.driverManager.Delete(driverId);
            return Ok();
        }

    }
}

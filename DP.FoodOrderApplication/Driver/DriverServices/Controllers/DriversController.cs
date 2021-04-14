using DriverServices.BL.Interfaces;
using DriverServices.BusinessEntities.RequestModel;
using DriverServices.BusinessEntities.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDriverManager _driverManager;
        public DriversController(IDriverManager driverManager)
        {
            this._driverManager = driverManager;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _driverManager.GetAll();
            return Ok(response);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _driverManager.Get(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(AddDriverRequestModel driver)
        {
            await _driverManager.Add(driver);
            return Ok();
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Update(DriverResponseModel driver)
        {
            await _driverManager.Update(driver);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _driverManager.Delete(id);
            return Ok();
        }
    }
}

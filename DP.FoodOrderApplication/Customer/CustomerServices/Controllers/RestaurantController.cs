using CustomerServices.BL.Interfaces;
using CustomerServices.BusinessEntities.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private IRestaurantManager _restaurantManager;
        public RestaurantController(IRestaurantManager restaurantManager)
        {
            this._restaurantManager = restaurantManager;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _restaurantManager.GetAll();
            return Ok(response);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _restaurantManager.Get(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(RestaurantResponseModel restaurant)
        {
            await _restaurantManager.Add(restaurant);
            return Ok();
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Update(RestaurantResponseModel restaurant)
        {
            await _restaurantManager.Update(restaurant);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _restaurantManager.Delete(id);
            return Ok();
        }
    }
}

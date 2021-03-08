using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderServices.BL.Interfaces;
using OrderServices.BusinessEntities.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private IRestaurantManager restaurantManager;
        public RestaurantController(IRestaurantManager restaurantManager)
        {
            this.restaurantManager = restaurantManager;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(RestaurantRequestModel restaurant)
        {
            await this.restaurantManager.Create(restaurant);
            return Ok();
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(RestaurantRequestModel restaurant)
        {
            await this.restaurantManager.Edit(restaurant);
            return Ok();
        }

        [HttpPost]
        [Route("Delete/{restaurantId}")]
        public async Task<IActionResult> Delete(int restaurantId)
        {
            await this.restaurantManager.Delete(restaurantId);
            return Ok();
        }
    }
}

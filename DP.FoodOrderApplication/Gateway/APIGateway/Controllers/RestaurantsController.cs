using APIGateway.Models;
using Infrastructure.Common.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private IConfiguration Configuration;
        public RestaurantsController(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit(Restaurant restaurant)
        {
            string EditRestaurantUri = $"${Configuration["RestaurantServiceEndpoint"]}/Restaurant/Edit";
            await HttpRequestClient.PutRequest<object>(EditRestaurantUri, restaurant);

            string EditRestaurantForCustomerMicroserviceUri = $"${Configuration["CusotmerServiceEndpoint"]}/Restaurant/Edit";
            await HttpRequestClient.PutRequest<object>(EditRestaurantForCustomerMicroserviceUri, restaurant);

            string EditRestaurantForOrderMicroserviceUri = $"${Configuration["OrderServiceEndpoint"]}/Restaurant/Edit";
            await HttpRequestClient.PutRequest<object>(EditRestaurantForOrderMicroserviceUri, restaurant);

            return Ok();
        }

        [HttpPut]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int restaurantId)
        {
            string DeleteRestaurantUri = $"${Configuration["RestaurantServiceEndpoint"]}/Restaurant/Delete/${restaurantId}";
            await HttpRequestClient.DeleteRequest<object>(DeleteRestaurantUri);

            string DeleteRestaurantForCustomerMicroserviceUri = $"${Configuration["CusotmerServiceEndpoint"]}/Restaurant/Delete/${restaurantId}";
            await HttpRequestClient.DeleteRequest<object>(DeleteRestaurantForCustomerMicroserviceUri);

            string DeleteRestaurantForOrderMicroserviceUri = $"${Configuration["OrderServiceEndpoint"]}/Restaurant/Delete/${restaurantId}";
            await HttpRequestClient.DeleteRequest<object>(DeleteRestaurantForOrderMicroserviceUri);

            return Ok();
        }

    }
}

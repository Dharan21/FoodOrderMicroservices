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
    public class MenuItemController : ControllerBase
    {
        private IConfiguration Configuration;
        public MenuItemController(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(MenuItem menuItem)
        {
            string AddMenuItemUri = $"{Configuration["RestaurantServiceEndpoint"]}/MenuItem/Add";
            var response = await HttpRequestClient.PostRequest<AddResponseModel>(AddMenuItemUri, menuItem);

            menuItem.Id = response.Id;

            string AddMenuItemForCustomerMicroserviceUri = $"{Configuration["CusotmerServiceEndpoint"]}/MenuItem/Add";
            await HttpRequestClient.PostRequest<object>(AddMenuItemForCustomerMicroserviceUri, menuItem);

            string AddMenuItemForOrderMicroserviceUri = $"{Configuration["OrderServiceEndpoint"]}/MenuItem/Add";
            await HttpRequestClient.PostRequest<object>(AddMenuItemForOrderMicroserviceUri, menuItem);

            return Ok();
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit(MenuItem menuItem)
        {
            string EditMenuItemUri = $"{Configuration["RestaurantServiceEndpoint"]}/MenuItem/Edit";
            await HttpRequestClient.PutRequest<object>(EditMenuItemUri, menuItem);

            string EditMenuItemForCustomerMicroserviceUri = $"{Configuration["CusotmerServiceEndpoint"]}/MenuItem/Edit";
            await HttpRequestClient.PutRequest<object>(EditMenuItemForCustomerMicroserviceUri, menuItem);

            string EditMenuItemForOrderMicroserviceUri = $"{Configuration["OrderServiceEndpoint"]}/MenuItem/Edit";
            await HttpRequestClient.PutRequest<object>(EditMenuItemForOrderMicroserviceUri, menuItem);

            return Ok();
        }

        [HttpPut]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int menuItemId)
        {
            string DeleteMenuItemUri = $"{Configuration["RestaurantServiceEndpoint"]}/MenuItem/Delete/{menuItemId}";
            await HttpRequestClient.DeleteRequest<object>(DeleteMenuItemUri);

            string DeleteMenuItemForCustomerMicroserviceUri = $"{Configuration["CusotmerServiceEndpoint"]}/MenuItem/Delete/{menuItemId}";
            await HttpRequestClient.DeleteRequest<object>(DeleteMenuItemForCustomerMicroserviceUri);

            string DeleteMenuItemForOrderMicroserviceUri = $"{Configuration["OrderServiceEndpoint"]}/MenuItem/Delete/{menuItemId}";
            await HttpRequestClient.DeleteRequest<object>(DeleteMenuItemForOrderMicroserviceUri);

            return Ok();
        }
    }
}

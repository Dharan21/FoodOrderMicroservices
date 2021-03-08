using APIGateway.Models;
using Infrastructure.Common.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Infrastructure.Common.Enumerators.Enumerators;

namespace APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IConfiguration Configuration;
        public UsersController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost]
        [Route("AddCustomer")]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            User user = new User()
            {
                Email = customer.Email,
                Password = customer.Password,
                Role = UserRole.Customer
            };
            string AddUserUri = $"${Configuration["AuthorizationServiceEndpoint"]}/Users/Add";
            var response = await HttpRequestClient.PostRequest<object>(AddUserUri, user);
            if (response != null)
            {
                string AddCustomerUri = $"${Configuration["CusotmerServiceEndpoint"]}/Customers/Add";
                await HttpRequestClient.PostRequest<object>(AddCustomerUri, customer);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("AddDriver")]
        public async Task<IActionResult> AddDriverUser(Driver driver)
        {
            User user = new User()
            {
                Email = driver.Email,
                Password = driver.Password,
                Role = UserRole.Driver
            };
            string AddUserUri = $"${Configuration["AuthorizationServiceEndpoint"]}/Users/Add";
            var response = await HttpRequestClient.PostRequest<object>(AddUserUri, user);
            if(response != null)
            {
                string AddDriverUri = $"${Configuration["DriverServiceEndpoint"]}/Drivers/Add";
                await HttpRequestClient.PostRequest<object>(AddDriverUri, driver);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("AddRestaurant")]
        public async Task<IActionResult> AddRestaurantUser(Restaurant restaurant)
        {
            User user = new User()
            {
                Email = restaurant.Email,
                Password = restaurant.Password,
                Role = UserRole.Restaurant
            };
            string AddUserUri = $"${Configuration["AuthorizationServiceEndpoint"]}/Users/Add";
            var response = await HttpRequestClient.PostRequest<object>(AddUserUri, user);
            if (response != null)
            {
                
                string AddRestaurantUri = $"${Configuration["RestaurantServiceEndpoint"]}/Restaurant/Add";
                await HttpRequestClient.PostRequest<object>(AddRestaurantUri, restaurant);

                string AddRestaurantInCustomerServiceUri = $"${Configuration["CusotmerServiceEndpoint"]}/Restaurant/Add";
                await HttpRequestClient.PostRequest<object>(AddRestaurantInCustomerServiceUri, restaurant);

                string AddRestaurantInOrderServiceUri = $"${Configuration["OrderServiceEndpoint"]}/Restaurant/Add";
                await HttpRequestClient.PostRequest<object>(AddRestaurantInOrderServiceUri, restaurant);
                return Ok();
            }
            return BadRequest();
        }

    }
}

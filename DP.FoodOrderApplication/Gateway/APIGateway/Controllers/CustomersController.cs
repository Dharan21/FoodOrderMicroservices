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
    public class CustomersController : ControllerBase
    {
        private IConfiguration Configuration;
        public CustomersController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        [Route("GetOrders")]
        public async Task<IActionResult> GetOrders(int customerId)
        {
            string GetCustomerUri = $"${Configuration["CusotmerServiceEndpoint"]}/Customers/Get/${customerId}";
            CustomerDetails customerDetails = await HttpRequestClient.GetRequest<CustomerDetails>(GetCustomerUri);

            string GetOrderUri = $"${Configuration["OrderServiceEndpoint"]}/Orders/GetByCustomer/${customerId}";
            List<OrderDetails> orderDetails = await HttpRequestClient.GetRequest<List<OrderDetails>>(GetOrderUri);

            if (orderDetails == null)
                orderDetails = new List<OrderDetails>();

            customerDetails.OrderDetails = orderDetails;
            return Ok(customerDetails);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderServices.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderManager _orderManager;
        public OrdersController(IOrderManager orderManager)
        {
            this._orderManager = orderManager;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var orders = await this._orderManager.GetAll();
            return Ok(orders);
        }
    }
}

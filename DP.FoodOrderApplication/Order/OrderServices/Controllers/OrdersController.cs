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

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(OrderRequestModel order)
        {
            await this._orderManager.Add(order);
            return Ok();
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit(OrderRequestModel order)
        {
            await this._orderManager.Edit(order);
            return Ok();
        }

        [HttpPut]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int orderId)
        {
            await this._orderManager.Delete(orderId);
            return Ok();
        }

        [HttpPost]
        [Route("AssignDriver")]
        public async Task<IActionResult> AssignDriver(AssignDriverRequestModel model)
        {
            await this._orderManager.AssignDriver(model);
            return Ok();
        }


    }
}

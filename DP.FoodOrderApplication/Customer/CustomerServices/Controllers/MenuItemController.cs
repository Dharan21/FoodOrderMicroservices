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
    public class MenuItemController : ControllerBase
    {
        private IMenuItemManager _menuItemManager;
        public MenuItemController(IMenuItemManager menuItemManager)
        {
            this._menuItemManager = menuItemManager;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _menuItemManager.GetAll();
            return Ok(response);
        }

        [HttpGet]
        [Route("GetByRestaurant/{restaurantId}")]
        public async Task<IActionResult> GetByRestaurant(int restaurantId)
        {
            var response = await _menuItemManager.GetByRestaurant(restaurantId);
            return Ok(response);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _menuItemManager.Get(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(MenuItemResponseModel menuItem)
        {
            await _menuItemManager.Add(menuItem);
            return Ok();
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Update(MenuItemResponseModel menuItem)
        {
            await _menuItemManager.Update(menuItem);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _menuItemManager.Delete(id);
            return Ok();
        }
    }
}

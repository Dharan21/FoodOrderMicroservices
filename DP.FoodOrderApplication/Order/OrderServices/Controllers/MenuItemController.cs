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
    public class MenuItemController : ControllerBase
    {
        private IMenuItemManager menuItemManager;
        public MenuItemController(IMenuItemManager menuItemManager)
        {
            this.menuItemManager = menuItemManager;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(MenuItemRequestModel menuItem)
        {
            await this.menuItemManager.Create(menuItem);
            return Ok();
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit(MenuItemRequestModel menuItem)
        {
            await this.menuItemManager.Edit(menuItem);
            return Ok();
        }

        [HttpPost]
        [Route("Delete/{restaurantId}")]
        public async Task<IActionResult> Delete(int menuItemId)
        {
            await this.menuItemManager.Delete(menuItemId);
            return Ok();
        }
    }
}

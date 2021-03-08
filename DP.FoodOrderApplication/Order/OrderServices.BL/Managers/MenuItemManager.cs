using AutoMapper;
using OrderServices.BL.Interfaces;
using OrderServices.BusinessEntities.RequestModels;
using OrderServices.DataEntities.Entities;
using OrderServices.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderServices.BL.Managers
{
    public class MenuItemManager : IMenuItemManager
    {
        private IMenuItemRepository menuItemRepository;
        private IMapper mapper;
        public MenuItemManager(IMenuItemRepository menuItemRepository, IMapper mapper)
        {
            this.menuItemRepository = menuItemRepository;
            this.mapper = mapper;
        }

        public async Task Create(MenuItemRequestModel menuItem)
        {
            MenuItem menuItemEntity = this.mapper.Map<MenuItemRequestModel, MenuItem>(menuItem);
            await this.menuItemRepository.Create(menuItemEntity);
        }

        public async Task Delete(int menuItemId)
        {
            MenuItem menuItemEntity =  await this.menuItemRepository.FindAsync(x => x.MenuItemId == menuItemId);
            await this.menuItemRepository.Delete(menuItemEntity.Id);
        }

        public async Task Edit(MenuItemRequestModel menuItem)
        {
            MenuItem menuItemEntity = await this.menuItemRepository.FindAsync(x => x.MenuItemId == menuItem.Id);
            menuItemEntity.Name = menuItem.Name;
            menuItemEntity.Price = menuItem.Price;
            await this.menuItemRepository.Update(menuItemEntity);
        }
    }
}

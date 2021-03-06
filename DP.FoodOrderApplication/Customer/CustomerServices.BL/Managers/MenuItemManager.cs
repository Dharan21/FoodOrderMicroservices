using AutoMapper;
using CustomerServices.BL.Interfaces;
using CustomerServices.BusinessEntities.ResponseModels;
using CustomerServices.DataEntities.Entities;
using CustomerServices.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerServices.BL.Managers
{
    public class MenuItemManager : IMenuItemManager
    {
        private IMenuItemRepository _menuItemRepository;
        private IMapper _mapper;
        public MenuItemManager(IMenuItemRepository menuItemRepository, IMapper mapper)
        {
            this._menuItemRepository = menuItemRepository;
            this._mapper = mapper;
        }


        public async Task Add(MenuItemResponseModel menuItem)
        {
            MenuItem menuItemEntity = this._mapper.Map<MenuItemResponseModel, MenuItem>(menuItem);
            await this._menuItemRepository.Create(menuItemEntity);
        }

        public async Task Delete(int id)
        {
            MenuItem menuItemEntity = await this._menuItemRepository.FindAsync(x => x.MenuItemId == id);
            await this._menuItemRepository.Delete(menuItemEntity.Id);
        }

        public async Task<MenuItemResponseModel> Get(int id)
        {
            MenuItem restaurantEntity = await this._menuItemRepository.FindAsync(x => x.MenuItemId == id);
            return this._mapper.Map<MenuItem, MenuItemResponseModel>(restaurantEntity);
        }

        public async Task<List<MenuItemResponseModel>> GetAll()
        {
            List<MenuItem> restaurantsEntity = await this._menuItemRepository.GetAll();
            return this._mapper.Map<List<MenuItem>, List<MenuItemResponseModel>>(restaurantsEntity);
        }

        public async Task<List<MenuItemResponseModel>> GetByRestaurant(int restaurantId)
        {
            List<MenuItem> restaurantsEntity = await this._menuItemRepository.FindAllAsync(x => x.RestaurantId == restaurantId);
            return this._mapper.Map<List<MenuItem>, List<MenuItemResponseModel>>(restaurantsEntity);
        }

        public async Task Update(MenuItemResponseModel menuItem)
        {
            MenuItem menuItemEntity = await this._menuItemRepository.FindAsync(x => x.MenuItemId == menuItem.MenuItemId);
            menuItemEntity.IsAvailable = menuItem.IsAvailable;
            menuItemEntity.Name = menuItem.Name;
            menuItemEntity.Price = menuItem.Price;
            await this._menuItemRepository.Update(menuItemEntity);
        }
    }
}

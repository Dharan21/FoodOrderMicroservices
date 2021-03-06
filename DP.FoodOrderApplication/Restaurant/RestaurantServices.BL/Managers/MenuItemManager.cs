using AutoMapper;
using RestaurantServices.BL.Interfaces;
using RestaurantServices.BusinessEntities.ResponseModels;
using RestaurantServices.DataEntities.Entities;
using RestaurantServices.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantServices.BL.Managers
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

        public async Task<List<MenuItemResponseModel>> GetAll()
        {
            List<MenuItem> menuItemsEntity = await this._menuItemRepository.GetAll();
            return this._mapper.Map<List<MenuItem>, List<MenuItemResponseModel>>(menuItemsEntity);
        }

        public async Task<MenuItemResponseModel> Get(int id)
        {
            MenuItem menuItemEntity = await this._menuItemRepository.GetById(id);
            return this._mapper.Map<MenuItem, MenuItemResponseModel>(menuItemEntity);
        }

        public async Task Add(MenuItemResponseModel menuItem)
        {
            MenuItem menuItemEntity = this._mapper.Map<MenuItemResponseModel, MenuItem>(menuItem);
            await this._menuItemRepository.Create(menuItemEntity);
        }

        public async Task Update(MenuItemResponseModel menuItem)
        {
            MenuItem menuItemEntity = this._mapper.Map<MenuItemResponseModel, MenuItem>(menuItem);
            await this._menuItemRepository.Update(menuItemEntity);
        }
        public async Task Delete(int id)
        {
            await this._menuItemRepository.Delete(id);
        }
    }
}

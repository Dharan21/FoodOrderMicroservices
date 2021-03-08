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
    public class RestaurantManager : IRestaurantManager
    {
        private IRestaurantRepository restaurantRepository;
        private IMenuItemRepository menuItemRepository;
        private IMapper mapper;
        public RestaurantManager(IRestaurantRepository restaurantRepository, IMapper mapper, IMenuItemRepository menuItemRepository)
        {
            this.restaurantRepository = restaurantRepository;
            this.menuItemRepository = menuItemRepository;
            this.mapper = mapper;
        }

        public async Task Create(RestaurantRequestModel restaurant)
        {
            Restaurant restaurantEntity = this.mapper.Map<RestaurantRequestModel, Restaurant>(restaurant);
            await this.restaurantRepository.Create(restaurantEntity);
        }

        public async Task Delete(int restaurantId)
        {
            Restaurant restaurantEntity = await this.restaurantRepository.FindAsync(x => x.RestaurantId == restaurantId);
            await this.restaurantRepository.Delete(restaurantEntity.Id);
        }

        public async Task Edit(RestaurantRequestModel restaurant)
        {
            Restaurant restaurantEntity = await this.restaurantRepository.FindAsync(x => x.RestaurantId == restaurant.Id);
            restaurantEntity.Name = restaurant.Name;
            restaurantEntity.Location = restaurant.Location;
            await this.restaurantRepository.Update(restaurantEntity);
        }
    }
}

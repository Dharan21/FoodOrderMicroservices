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
    public class RestaurantManager : IRestaurantManager
    {
        private IRestaurantRepository _restaurantRepository;
        private IMapper _mapper;
        public RestaurantManager(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            this._restaurantRepository = restaurantRepository;
            this._mapper = mapper;
        }

        public async Task Add(RestaurantResponseModel restaurant)
        {
            Restaurant restaurantEntity = this._mapper.Map<RestaurantResponseModel, Restaurant>(restaurant);
            await this._restaurantRepository.Create(restaurantEntity);
        }

        public async Task Delete(int id)
        {
            Restaurant restaurantEntity = await this._restaurantRepository.FindAsync(x => x.RestaurantId == id);
            await this._restaurantRepository.Delete(restaurantEntity.Id);
        }

        public async Task<RestaurantResponseModel> Get(int id)
        {
            Restaurant restaurantEntity = await this._restaurantRepository.FindAsync(x => x.RestaurantId == id);
            return this._mapper.Map<Restaurant, RestaurantResponseModel>(restaurantEntity);
        }

        public async Task<List<RestaurantResponseModel>> GetAll()
        {
            List<Restaurant> restaurantsEntity = await this._restaurantRepository.GetAll();
            return this._mapper.Map<List<Restaurant>, List<RestaurantResponseModel>>(restaurantsEntity);
        }

        public async Task Update(RestaurantResponseModel restaurant)
        {
            Restaurant restaurantEntity = await this._restaurantRepository.FindAsync(x => x.RestaurantId == restaurant.RestaurantId);
            restaurantEntity.Location = restaurant.Location;
            restaurant.Name = restaurant.Name;
            await this._restaurantRepository.Update(restaurantEntity);
        }
    }
}

using AutoMapper;
using RestaurantServices.BL.Interfaces;
using RestaurantServices.BusinessEntities.RequestModels;
using RestaurantServices.BusinessEntities.ResponseModels;
using RestaurantServices.DataEntities.Entities;
using RestaurantServices.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantServices.BL.Managers
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

        public async Task<List<RestaurantResponseModel>> GetAll()
        {
            List<Restaurant> restaurantsEntity = await this._restaurantRepository.GetAll();
            return this._mapper.Map<List<Restaurant>, List<RestaurantResponseModel>>(restaurantsEntity);
        }

        public async Task<RestaurantResponseModel> Get(int id)
        {
            Restaurant restaurantEntity = await this._restaurantRepository.GetById(id);
            return this._mapper.Map<Restaurant, RestaurantResponseModel>(restaurantEntity);
        }

        public async Task<int> Add(RestaurantRequestModel restaurant)
        {
            Restaurant restaurantEntity = this._mapper.Map<RestaurantRequestModel, Restaurant>(restaurant);
            return await this._restaurantRepository.CreateRestaurant(restaurantEntity);
        }

        public async Task Update(RestaurantRequestModel restaurant)
        {
            Restaurant restaurantEntity = this._mapper.Map<RestaurantRequestModel, Restaurant>(restaurant);
            await this._restaurantRepository.Update(restaurantEntity);
        }
        public async Task Delete(int id)
        {
            await this._restaurantRepository.Delete(id);
        }
    }
}

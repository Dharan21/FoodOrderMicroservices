using AutoMapper;
using Grpc.Net.Client;
using Infrastructure.Common.Constants;
using Infrastructure.Common.Utility;
using Microsoft.Extensions.Configuration;
using RestaurantServices.BL.Interfaces;
using RestaurantServices.BusinessEntities;
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
        private IConfiguration _configuration;

        public RestaurantManager(IRestaurantRepository restaurantRepository, IMapper mapper, IConfiguration configuration)
        {
            this._restaurantRepository = restaurantRepository;
            this._mapper = mapper;
            this._configuration = configuration;
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

        public async Task Add(RestaurantRequestModel restaurant)
        {
            Restaurant restaurantEntity = this._mapper.Map<RestaurantRequestModel, Restaurant>(restaurant);
            await this._restaurantRepository.Create(restaurantEntity);

            var user = new AuthGrpcService.Protos.AddUserRequestModel()
            {
                Email = restaurant.Email,
                Password = restaurant.Password,
                Role = AuthGrpcService.Protos.UserRole.Restaurant
            };
            //string AddUser = $"{_configuration[Constants.GatewayEndPointKey]}/{Constants.AuthenticationServicesPrefix}/{Constants.AuthenticationServiceUsersController}/{Constants.Add}";
            //await HttpRequestClient.PostRequest<object>(AddUser, user);

            var channel = GrpcChannel.ForAddress("https://localhost:8001");
            var client = new AuthGrpcService.Protos.UserProtoService.UserProtoServiceClient(channel);

            await client.AddUserAsync(user);
        }

        public async Task Update(RestaurantRequestModel restaurant)
        {
            Restaurant restaurantEntity = await this._restaurantRepository.GetById(restaurant.Id);
            restaurantEntity.Name = restaurant.Name;
            restaurantEntity.Location = restaurant.Location;
            await this._restaurantRepository.Update(restaurantEntity);
        }
        public async Task Delete(int id)
        {
            await this._restaurantRepository.Delete(id);
        }
    }
}

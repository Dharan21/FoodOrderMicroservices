using AutoMapper;
using Grpc.Core;
using RestaurantGrpcService.Protos;
using RestaurantServices.BL.Interfaces;
using RestaurantServices.BusinessEntities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantGrpcService.Services
{
    public class RestaurantGrpcProtoService : RestaurantProtoService.RestaurantProtoServiceBase
    {
        private readonly IRestaurantManager restaurantManager;
        private readonly IMapper mapper;

        public RestaurantGrpcProtoService(IRestaurantManager restaurantManager, IMapper mapper)
        {
            this.restaurantManager = restaurantManager;
            this.mapper = mapper;
        }

        public async override Task<GetRestaurantResposneModel> GetRestaurant(GetRestaurantRequestModel request, ServerCallContext context)
        {
            var result = await this.restaurantManager.Get(request.RestaurantId);
            return this.mapper.Map<RestaurantResponseModel, GetRestaurantResposneModel>(result);
        }
    }
}

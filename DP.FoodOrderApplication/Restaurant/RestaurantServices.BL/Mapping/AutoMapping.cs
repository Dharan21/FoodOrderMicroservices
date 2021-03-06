using AutoMapper;
using RestaurantServices.BusinessEntities.RequestModels;
using RestaurantServices.BusinessEntities.ResponseModels;
using RestaurantServices.DataEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantServices.BL.Mapping
{
    public static class AutoMapping
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Restaurant, RestaurantResponseModel>().ReverseMap();
            cfg.CreateMap<RestaurantRequestModel, Restaurant>().ReverseMap();

            cfg.CreateMap<MenuItem, MenuItemResponseModel>().ReverseMap();
        }
    }
}

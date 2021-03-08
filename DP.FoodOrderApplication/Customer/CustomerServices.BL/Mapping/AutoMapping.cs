using AutoMapper;
using CustomerServices.BusinessEntities.ResponseModels;
using CustomerServices.DataEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerServices.BL.Mapping
{
    public static class AutoMapping
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Customer, CustomerResponseModel>().ReverseMap();

            cfg.CreateMap<Restaurant, RestaurantResponseModel>();

            cfg.CreateMap<RestaurantResponseModel, Restaurant>()
                .ForMember(x => x.RestaurantId, cfg => cfg.MapFrom(src => src.Id))
                .ForMember(x => x.Id, cfg => cfg.Ignore())
                ;

            cfg.CreateMap<MenuItem, MenuItemResponseModel>();

            cfg.CreateMap<MenuItemResponseModel, MenuItem>()
                .ForMember(x => x.MenuItemId, cfg => cfg.MapFrom(src => src.Id))
                .ForMember(x => x.Id, cfg => cfg.Ignore())
                ;
        }
    }
}

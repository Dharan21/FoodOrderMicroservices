using AutoMapper;
using OrderServices.BusinessEntities.RequestModels;
using OrderServices.BusinessEntities.ResponseModels;
using OrderServices.DataEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static Infrastructure.Common.Enumerators.Enumerators;

namespace OrderServices.BL.Mapping
{
    public static class AutoMapping
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Order, OrderResponseModel>()
                .ForMember(x => x.OrderItems, cfg => cfg.Ignore())
                .ForMember(x => x.OrderNumber, cfg => cfg.MapFrom(src => src.Id + 1000))
                .ForMember(x => x.Status, cfg => cfg.MapFrom(src => src.Status.ToString()))
                ;

            cfg.CreateMap<OrderRequestModel, Order>()
                .ForMember(dest => dest.Id, cfg => cfg.Ignore())
                .ForMember(dest => dest.ItemsQuantity, cfg => cfg.Ignore())
                .ForMember(dest => dest.TotalPrice, cfg => cfg.Ignore())
                .ForMember(dest => dest.DriverId, cfg => cfg.Ignore())
                .ForMember(dest => dest.Status, cfg => cfg.MapFrom(x => OrderStatus.OrderPlaced))
                .ForMember(dest => dest.DateTime, cfg => cfg.MapFrom(x => DateTime.UtcNow))
                .ForMember(dest => dest.OrderDetails, cfg => cfg.Ignore())
                ;

            cfg.CreateMap<RestaurantRequestModel, Restaurant>()
                .ForMember(dest => dest.RestaurantId, cfg => cfg.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, cfg => cfg.Ignore())
                ;

            cfg.CreateMap<DriverRequestModel, Driver>()
                .ForMember(dest => dest.DriverId, cfg => cfg.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, cfg => cfg.Ignore())
                ;

            cfg.CreateMap<MenuItemRequestModel, MenuItem>()
                .ForMember(dest => dest.MenuItemId, cfg => cfg.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, cfg => cfg.Ignore())
                ;
        }
    }
}

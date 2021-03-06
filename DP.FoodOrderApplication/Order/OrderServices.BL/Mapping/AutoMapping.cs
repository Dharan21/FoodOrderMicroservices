using AutoMapper;
using OrderServices.BusinessEntities.ResponseModels;
using OrderServices.DataEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.BL.Mapping
{
    public static class AutoMapping
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Order, OrderResponseModel>()
                .ForMember(x => x.OrderItems, cfg => cfg.Ignore())
                ;
            cfg.CreateMap<MenuItem, OrderItemResponseModel>();
        }
    }
}

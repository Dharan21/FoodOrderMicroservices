using AutoMapper;
using DriverServices.BusinessEntities.ResponseModels;
using DriverServices.DataEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriverServices.BL.Mapping
{
    public static class AutoMapping
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Driver, DriverResponseModel>().ReverseMap();
        }
    }
}

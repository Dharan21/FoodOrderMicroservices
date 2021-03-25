using AutoMapper;
using CustomerServices.BusinessEntities.RequestModel;
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
            
            cfg.CreateMap<AddCustomerRequestModel, Customer>()
                .ForMember(dest => dest.Id, cfg => cfg.Ignore())
                ;
        }
    }
}

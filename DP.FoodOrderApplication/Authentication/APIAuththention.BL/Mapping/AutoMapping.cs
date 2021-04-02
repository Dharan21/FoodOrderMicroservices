using APIAuthentication.BusinessEntities.RequestModel;
using APIAuthentication.DataEntities.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAuthentication.BL.Mapping
{
    public static class AutoMapping
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<UserRequestModel, User>();
        }
    }
}

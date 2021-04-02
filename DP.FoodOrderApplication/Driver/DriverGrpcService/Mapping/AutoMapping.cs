using AutoMapper;
using DriverGrpcService.Protos;
using DriverServices.BusinessEntities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverGrpcService.Mapping
{
    internal static class AutoMapping
    {
        private static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<DriverResponseModel, GetDriverResponseModel>();

            DriverServices.BL.Mapping.AutoMapping.Configure(cfg);
        }

        private static IMapper _mapper;

        public static IMapper Instance
        {
            get
            {
                if (_mapper == null)
                {
                    _mapper = new MapperConfiguration(Configure).CreateMapper();
                }

                return _mapper;
            }
        }
    }
}

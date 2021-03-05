using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverServices.Mapping
{
    internal static class AutoMapping
    {
        private static void Configure(IMapperConfigurationExpression cfg)
        {
            BL.Mapping.AutoMapping.Configure(cfg);
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

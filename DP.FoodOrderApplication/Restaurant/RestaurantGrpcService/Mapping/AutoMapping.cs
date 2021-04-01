using AutoMapper;
using RestaurantGrpcService.Protos;
using RestaurantServices.BusinessEntities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantGrpcService.Mapping
{
    internal static class AutoMapping
    {
        private static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<MenuItemResponseModel, MenuItem>();
            cfg.CreateMap<RestaurantResponseModel, GetRestaurantResposneModel>()
                .ForMember(dest => dest.MenuItems, cfg => cfg.MapFrom(src => src.MenuItems))
                ;

            RestaurantServices.BL.Mapping.AutoMapping.Configure(cfg);
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

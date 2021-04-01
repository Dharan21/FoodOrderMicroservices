using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using RestaurantGrpcService.Protos;
using RestaurantServices.BL.Interfaces;

namespace RestaurantGrpcService.Services
{
    public class MenuItemGrpcProtoService : MenuItemProtoService.MenuItemProtoServiceBase
    {
        private readonly IMenuItemManager menuItemManager;
        private readonly IMapper mapper;

        public MenuItemGrpcProtoService(IMenuItemManager menuItemManager, IMapper mapper)
        {
            this.menuItemManager = menuItemManager;
            this.mapper = mapper;
        }

        public async override Task<GetMenuListResponse> GetMenuList(GetMenuListRequest request, ServerCallContext context)
        {
            var response = await this.menuItemManager.GetAll(request.Ids);
            GetMenuListResponse result = new GetMenuListResponse();
            result.MenuItems.AddRange(this.mapper.Map<List<MenuItem>>(response));
            return result;
        }
    }
}

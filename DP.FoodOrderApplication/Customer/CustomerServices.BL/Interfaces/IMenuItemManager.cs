using CustomerServices.BusinessEntities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerServices.BL.Interfaces
{
    public interface IMenuItemManager
    {
        Task<List<MenuItemResponseModel>> GetAll();
        Task<List<MenuItemResponseModel>> GetByRestaurant(int restaurantId);
        Task<MenuItemResponseModel> Get(int id);
        Task Add(MenuItemResponseModel menuItem);
        Task Update(MenuItemResponseModel menuItem);
        Task Delete(int id);
    }
}

using RestaurantServices.BusinessEntities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantServices.BL.Interfaces
{
    public interface IMenuItemManager
    {
        Task<List<MenuItemResponseModel>> GetAll();
        Task<List<MenuItemResponseModel>> GetAll(string ids);
        Task<MenuItemResponseModel> Get(int id);
        Task<int> Add(MenuItemResponseModel menuItem);
        Task Update(MenuItemResponseModel menuItem);
        Task Delete(int id);
    }
}

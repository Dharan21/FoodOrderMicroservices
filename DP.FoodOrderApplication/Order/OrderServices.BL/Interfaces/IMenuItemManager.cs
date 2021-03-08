using OrderServices.BusinessEntities.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderServices.BL.Interfaces
{
    public interface IMenuItemManager
    {
        Task Create(MenuItemRequestModel menuItem);
        Task Edit(MenuItemRequestModel menuItem);
        Task Delete(int menuItemId);
    }
}

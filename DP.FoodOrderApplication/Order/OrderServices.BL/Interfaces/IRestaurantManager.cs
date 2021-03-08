using OrderServices.BusinessEntities.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderServices.BL.Interfaces
{
    public interface IRestaurantManager
    {
        Task Create(RestaurantRequestModel restaurant);
        Task Edit(RestaurantRequestModel restaurant);
        Task Delete(int restaurantId);
    }
}

using CustomerServices.BusinessEntities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerServices.BL.Interfaces
{
    public interface IRestaurantManager
    {
        Task<List<RestaurantResponseModel>> GetAll();
        Task<RestaurantResponseModel> Get(int id);
        Task Add(RestaurantResponseModel restaurant);
        Task Update(RestaurantResponseModel restaurant);
        Task Delete(int id);
    }
}

using RestaurantServices.BusinessEntities.RequestModels;
using RestaurantServices.BusinessEntities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantServices.BL.Interfaces
{
    public interface IRestaurantManager
    {
        Task<List<RestaurantResponseModel>> GetAll();
        Task<RestaurantResponseModel> Get(int id);
        Task<int> Add(RestaurantRequestModel restaurant);
        Task Update(RestaurantRequestModel restaurant);
        Task Delete(int id);
    }
}

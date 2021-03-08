using DriverServices.BusinessEntities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DriverServices.BL.Interfaces
{
    public interface IDriverManager
    {
        Task<List<DriverResponseModel>> GetAll();
        Task<DriverResponseModel> Get(int id);
        Task<int> Add(DriverResponseModel driver);
        Task Update(DriverResponseModel driver);
        Task Delete(int id);
    }
}

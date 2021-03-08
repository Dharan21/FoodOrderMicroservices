using OrderServices.BusinessEntities.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderServices.BL.Interfaces
{
    public interface IDriverManager
    {
        Task Create(DriverRequestModel driver);
        Task Edit(DriverRequestModel driver);
        Task Delete(int driverId);
    }
}

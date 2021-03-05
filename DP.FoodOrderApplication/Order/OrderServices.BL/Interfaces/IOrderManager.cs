using OrderServices.BusinessEntities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderServices.BL.Interfaces
{
    public interface IOrderManager
    {
        Task<List<OrderResponseModel>> GetAll();
    }
}

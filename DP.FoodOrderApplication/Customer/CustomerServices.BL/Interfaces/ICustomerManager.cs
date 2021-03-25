using CustomerServices.BusinessEntities.RequestModel;
using CustomerServices.BusinessEntities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerServices.BL.Interfaces
{
    public interface ICustomerManager
    {
        Task<List<CustomerResponseModel>> GetAll();
        Task<CustomerResponseModel> Get(int id);
        Task Add(AddCustomerRequestModel customer);
        Task Update(CustomerResponseModel customer);
        Task Delete(int id);
    }
}

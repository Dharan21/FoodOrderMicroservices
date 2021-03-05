using CustomerServices.BL.Interfaces;
using CustomerServices.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerServices.BL.Managers
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerManager(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }
        public async Task<> GetAll()
        {
            return await this._customerRepository.GetAll();
        }
    }
}

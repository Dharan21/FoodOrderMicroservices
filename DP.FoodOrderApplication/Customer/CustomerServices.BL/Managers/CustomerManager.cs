using AutoMapper;
using CustomerServices.BL.Interfaces;
using CustomerServices.BusinessEntities.ResponseModels;
using CustomerServices.DataEntities.Entities;
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
        private readonly IMapper _mapper;

        public CustomerManager(ICustomerRepository customerRepository, IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
        }
        public async Task<List<CustomerResponseModel>> GetAll()
        {
            List<Customer> customersEntity =  await this._customerRepository.GetAll();
            return this._mapper.Map<List<Customer>, List<CustomerResponseModel>>(customersEntity);
        }

        public async Task<CustomerResponseModel> Get(int id)
        {
            Customer customerEntity = await this._customerRepository.GetById(id);
            return this._mapper.Map<Customer, CustomerResponseModel>(customerEntity);
        }

        public async Task Add(CustomerResponseModel customer)
        {
            Customer customerEntity = this._mapper.Map<CustomerResponseModel, Customer>(customer);
            await this._customerRepository.Create(customerEntity);
        }

        public async Task Update(CustomerResponseModel customer)
        {
            Customer customerEntity = this._mapper.Map<CustomerResponseModel, Customer>(customer);
            await this._customerRepository.Update(customerEntity);
        }
        public async Task Delete(int id)
        {
            await this._customerRepository.Delete(id);
        }

    }
}

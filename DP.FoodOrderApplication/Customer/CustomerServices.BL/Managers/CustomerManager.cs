using AutoMapper;
using CustomerServices.BL.Interfaces;
using CustomerServices.BusinessEntities;
using CustomerServices.BusinessEntities.RequestModel;
using CustomerServices.BusinessEntities.ResponseModels;
using CustomerServices.DataEntities.Entities;
using CustomerServices.DL.Interfaces;
using Infrastructure.Common.Constants;
using Infrastructure.Common.Utility;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public CustomerManager(ICustomerRepository customerRepository, IMapper mapper, IConfiguration configuration)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
            this._configuration = configuration;
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

        public async Task Add(AddCustomerRequestModel customer)
        {
            Customer customerEntity = this._mapper.Map<AddCustomerRequestModel, Customer>(customer);
            await this._customerRepository.Create(customerEntity);

            User user = new User()
            {
                Email = customer.Email,
                Password = customer.Password,
                Role = Infrastructure.Common.Enumerators.Enumerators.UserRole.Customer
            };
            string AddUser = $"{_configuration[Constants.GatewayEndPointKey]}/{Constants.AuthenticationServicesPrefix}/{Constants.AuthenticationServiceUsersController}/{Constants.Add}";
            await HttpRequestClient.PostRequest<object>(AddUser, user);
        }

        public async Task Update(CustomerResponseModel customer)
        {
            Customer customerEntity = await this._customerRepository.GetById(customer.Id);
            customerEntity.FirstName = customer.FirstName;
            customerEntity.LastName = customer.LastName;
            customerEntity.Mobile = customer.Mobile;
            customerEntity.Address = customer.Address;
            await this._customerRepository.Update(customerEntity);
        }
        public async Task Delete(int id)
        {
            await this._customerRepository.Delete(id);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using CustomerGrpcService.Protos;
using System.Threading.Tasks;
using Grpc.Core;
using CustomerServices.BL.Interfaces;
using AutoMapper;
using CustomerServices.DataEntities.Entities;
using CustomerServices.BusinessEntities.ResponseModels;

namespace CustomerGrpcService.Services
{
    public class CustomerService : CustomerGrpcProtoService.CustomerGrpcProtoServiceBase
    {
        private readonly ICustomerManager customerManager;
        public readonly IMapper mapper;
        public CustomerService(ICustomerManager customerManager, IMapper mapper)
        {
            this.customerManager = customerManager;
            this.mapper = mapper;
        }


        public async override Task<GetCustomerResponse> GetCustomer(GetCustomerRequest request, ServerCallContext context)
        {
            var customer = await this.customerManager.Get(request.CustomerId);
            return this.mapper.Map<CustomerResponseModel, GetCustomerResponse>(customer);
          
        }
    }
}

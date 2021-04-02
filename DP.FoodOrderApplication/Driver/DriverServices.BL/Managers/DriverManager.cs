using AutoMapper;
using DriverServices.BL.Interfaces;
using DriverServices.BusinessEntities;
using DriverServices.BusinessEntities.RequestModel;
using DriverServices.BusinessEntities.ResponseModels;
using DriverServices.DataEntities.Entities;
using DriverServices.DL.Interfaces;
using Grpc.Net.Client;
using Infrastructure.Common.Constants;
using Infrastructure.Common.Utility;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DriverServices.BL.Managers
{
    public class DriverManager : IDriverManager
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public DriverManager(IDriverRepository driverRepository, IMapper mapper, IConfiguration configuration)
        {
            this._driverRepository = driverRepository;
            this._mapper = mapper;
            this._configuration = configuration;
        }
        public async Task<List<DriverResponseModel>> GetAll()
        {
            List<Driver> driversEntity = await this._driverRepository.GetAll();
            return this._mapper.Map<List<Driver>, List<DriverResponseModel>>(driversEntity);
        }

        public async Task<DriverResponseModel> Get(int id)
        {
            Driver driverEntity = await this._driverRepository.GetById(id);
            return this._mapper.Map<Driver, DriverResponseModel>(driverEntity);
        }

        public async Task Add(AddDriverRequestModel driver)
        {
            Driver driverEntity = this._mapper.Map<AddDriverRequestModel, Driver>(driver);
            await this._driverRepository.Create(driverEntity);

            var user = new AuthGrpcService.Protos.AddUserRequestModel()
            {
                Email = driver.Email,
                Password = driver.Password,
                Role = AuthGrpcService.Protos.UserRole.Driver
            };
            //string AddUser = $"{_configuration[Constants.GatewayEndPointKey]}/{Constants.AuthenticationServicesPrefix}/{Constants.AuthenticationServiceUsersController}/{Constants.Add}";
            //await HttpRequestClient.PostRequest<object>(AddUser, user);

            var channel = GrpcChannel.ForAddress("https://localhost:8001");
            var client = new AuthGrpcService.Protos.UserProtoService.UserProtoServiceClient(channel);

            await client.AddUserAsync(user);
        }

        public async Task Update(DriverResponseModel driver)
        {
            Driver driverEntity = await this._driverRepository.GetById(driver.Id);
            driverEntity.FirstName = driver.FirstName;
            driverEntity.LastName = driver.LastName;
            driverEntity.Mobile = driver.Mobile;
            await this._driverRepository.Update(driverEntity);
        }
        public async Task Delete(int id)
        {
            await this._driverRepository.Delete(id);
        }
    }
}

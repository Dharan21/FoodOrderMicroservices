using AutoMapper;
using DriverServices.BL.Interfaces;
using DriverServices.BusinessEntities.ResponseModels;
using DriverServices.DataEntities.Entities;
using DriverServices.DL.Interfaces;
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

        public DriverManager(IDriverRepository driverRepository, IMapper mapper)
        {
            this._driverRepository = driverRepository;
            this._mapper = mapper;
        }
        public async Task<List<DriverResponseModel>> GetAll()
        {
            List<Driver> customersEntity = await this._driverRepository.GetAll();
            return this._mapper.Map<List<Driver>, List<DriverResponseModel>>(customersEntity);
        }

        public async Task<DriverResponseModel> Get(int id)
        {
            Driver customerEntity = await this._driverRepository.GetById(id);
            return this._mapper.Map<Driver, DriverResponseModel>(customerEntity);
        }

        public async Task Add(DriverResponseModel customer)
        {
            Driver customerEntity = this._mapper.Map<DriverResponseModel, Driver>(customer);
            await this._driverRepository.Create(customerEntity);
        }

        public async Task Update(DriverResponseModel customer)
        {
            Driver customerEntity = this._mapper.Map<DriverResponseModel, Driver>(customer);
            await this._driverRepository.Update(customerEntity);
        }
        public async Task Delete(int id)
        {
            await this._driverRepository.Delete(id);
        }
    }
}

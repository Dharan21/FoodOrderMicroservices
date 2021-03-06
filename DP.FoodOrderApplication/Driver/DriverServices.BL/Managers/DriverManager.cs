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
            List<Driver> driversEntity = await this._driverRepository.GetAll();
            return this._mapper.Map<List<Driver>, List<DriverResponseModel>>(driversEntity);
        }

        public async Task<DriverResponseModel> Get(int id)
        {
            Driver driverEntity = await this._driverRepository.GetById(id);
            return this._mapper.Map<Driver, DriverResponseModel>(driverEntity);
        }

        public async Task Add(DriverResponseModel driver)
        {
            Driver driverEntity = this._mapper.Map<DriverResponseModel, Driver>(driver);
            await this._driverRepository.Create(driverEntity);
        }

        public async Task Update(DriverResponseModel driver)
        {
            Driver driverEntity = this._mapper.Map<DriverResponseModel, Driver>(driver);
            await this._driverRepository.Update(driverEntity);
        }
        public async Task Delete(int id)
        {
            await this._driverRepository.Delete(id);
        }
    }
}

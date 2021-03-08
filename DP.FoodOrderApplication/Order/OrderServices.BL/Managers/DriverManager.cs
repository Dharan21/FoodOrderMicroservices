using AutoMapper;
using OrderServices.BL.Interfaces;
using OrderServices.BusinessEntities.RequestModels;
using OrderServices.DataEntities.Entities;
using OrderServices.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderServices.BL.Managers
{
    public class DriverManager : IDriverManager
    {
        private IDriverRepository driverRepository;
        private IMapper mapper;
        public DriverManager(IDriverRepository driverRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.driverRepository = driverRepository;
        }

        public async Task Create(DriverRequestModel driver)
        {
            Driver driverEntity = this.mapper.Map<DriverRequestModel, Driver>(driver);
            await this.driverRepository.Create(driverEntity);
        }

        public async Task Delete(int driverId)
        {
            Driver driverEntity =  await this.driverRepository.FindAsync(x => x.DriverId == driverId);
            await this.driverRepository.Delete(driverEntity.Id);
        }

        public async Task Edit(DriverRequestModel driver)
        {
            Driver driverEntity = await this.driverRepository.FindAsync(x => x.DriverId == driver.Id);
            driverEntity.FirstName = driver.FirstName;
            driverEntity.LastName = driver.LastName;
            driverEntity.Mobile = driver.Mobile;
            await this.driverRepository.Update(driverEntity);
        }
    }
}

using DriverServices.DataEntities.Entities;
using Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DriverServices.DL.Interfaces
{
    public interface IDriverRepository : IGenericRepository<Driver>
    {
        Task<int> CreateDriver(Driver driver);
    }
}

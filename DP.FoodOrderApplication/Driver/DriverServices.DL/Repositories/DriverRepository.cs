using DriverServices.DataEntities;
using DriverServices.DataEntities.Entities;
using DriverServices.DL.Interfaces;
using Infrastructure.Repository.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DriverServices.DL.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        private DriverDbContext _context;
        public DriverRepository(DriverDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<int> CreateDriver(Driver driver)
        {
            this._context.Drivers.Add(driver);
            await this._context.SaveChangesAsync();
            return driver.Id;
        }
    }
}

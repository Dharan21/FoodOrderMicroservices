using DriverServices.DataEntities;
using DriverServices.DataEntities.Entities;
using DriverServices.DL.Interfaces;
using Infrastructure.Repository.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriverServices.DL.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        private DriverDbContext _context;
        public DriverRepository(DriverDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}

using Infrastructure.Repository.Classes;
using OrderServices.DataEntities;
using OrderServices.DataEntities.Entities;
using OrderServices.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.DL.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        private OrderDbContext context;
        public DriverRepository(OrderDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}

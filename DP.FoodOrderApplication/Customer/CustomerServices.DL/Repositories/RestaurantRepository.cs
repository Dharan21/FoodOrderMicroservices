using CustomerServices.DataEntities;
using CustomerServices.DataEntities.Entities;
using CustomerServices.DL.Interfaces;
using Infrastructure.Repository.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerServices.DL.Repositories
{
    public class RestaurantRepository : GenericRepository<Restaurant>, IRestaurantRepository
    {
        private CustomerDbContext _context;
        public RestaurantRepository(CustomerDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}

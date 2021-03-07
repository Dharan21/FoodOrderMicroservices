using Infrastructure.Repository.Classes;
using OrderServices.DataEntities;
using OrderServices.DataEntities.Entities;
using OrderServices.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.DL.Repositories
{
    public class RestaurantRepository : GenericRepository<Restaurant>, IRestaurantRepository
    {
        private OrderDbContext context;
        public RestaurantRepository(OrderDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}

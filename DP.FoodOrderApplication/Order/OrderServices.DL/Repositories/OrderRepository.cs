using Infrastructure.Repository.Classes;
using OrderServices.DataEntities;
using OrderServices.DataEntities.Entities;
using OrderServices.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.DL.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private OrderDbContext _context;
        public OrderRepository(OrderDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}

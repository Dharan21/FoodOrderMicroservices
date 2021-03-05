using Infrastructure.Repository.Classes;
using OrderServices.DataEntities;
using OrderServices.DataEntities.Entities;
using OrderServices.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.DL.Repositories
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        private OrderDbContext _context;
        public OrderDetailRepository(OrderDbContext context) :  base(context)
        {
            this._context = context;
        }
    }
}

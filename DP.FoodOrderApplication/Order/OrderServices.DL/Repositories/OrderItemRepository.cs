using Infrastructure.Repository.Classes;
using OrderServices.DataEntities;
using OrderServices.DataEntities.Entities;
using OrderServices.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.DL.Repositories
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        private OrderDbContext _context;
        public OrderItemRepository(OrderDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}

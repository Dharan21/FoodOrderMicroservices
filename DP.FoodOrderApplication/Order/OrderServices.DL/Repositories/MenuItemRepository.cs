using Infrastructure.Repository.Classes;
using OrderServices.DataEntities;
using OrderServices.DataEntities.Entities;
using OrderServices.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.DL.Repositories
{
    public class MenuItemRepository : GenericRepository<MenuItem>, IMenuItemRepository
    {
        private OrderDbContext _context;
        public MenuItemRepository(OrderDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}

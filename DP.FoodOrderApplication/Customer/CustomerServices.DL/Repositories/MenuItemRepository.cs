using CustomerServices.DataEntities;
using CustomerServices.DataEntities.Entities;
using CustomerServices.DL.Interfaces;
using Infrastructure.Repository.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerServices.DL.Repositories
{
    public class MenuItemRepository : GenericRepository<MenuItem>, IMenuItemRepository
    {
        private CustomerDbContext _context;
        public MenuItemRepository(CustomerDbContext context) : base(context)
        {
            this._context = context;
        }

    }
}

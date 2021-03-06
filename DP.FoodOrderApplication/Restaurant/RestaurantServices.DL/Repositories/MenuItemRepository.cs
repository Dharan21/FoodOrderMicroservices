using Infrastructure.Repository.Classes;
using RestaurantServices.DataEntities;
using RestaurantServices.DataEntities.Entities;
using RestaurantServices.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantServices.DL.Repositories
{
    public class MenuItemRepository : GenericRepository<MenuItem>, IMenuItemRepository
    {
        private RestaurantDbContext _context;
        public MenuItemRepository(RestaurantDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}

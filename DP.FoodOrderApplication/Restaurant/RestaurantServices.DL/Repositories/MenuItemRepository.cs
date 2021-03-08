using Infrastructure.Repository.Classes;
using RestaurantServices.DataEntities;
using RestaurantServices.DataEntities.Entities;
using RestaurantServices.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantServices.DL.Repositories
{
    public class MenuItemRepository : GenericRepository<MenuItem>, IMenuItemRepository
    {
        private RestaurantDbContext _context;
        public MenuItemRepository(RestaurantDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<int> CreateMenuItem(MenuItem item)
        {
            this._context.MenuItems.Add(item);
            await this._context.SaveChangesAsync();
            return item.Id;
        }
    }
}

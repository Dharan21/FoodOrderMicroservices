using Infrastructure.Repository.Classes;
using Microsoft.EntityFrameworkCore;
using RestaurantServices.DataEntities;
using RestaurantServices.DataEntities.Entities;
using RestaurantServices.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantServices.DL.Repositories
{
    public class RestaurantRepository : GenericRepository<Restaurant>, IRestaurantRepository
    {
        private RestaurantDbContext _context;
        public RestaurantRepository(RestaurantDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<int> CreateRestaurant(Restaurant restaurant)
        {
            this._context.Restaurants.Add(restaurant);
            await this._context.SaveChangesAsync();
            return restaurant.Id;
        }

        public async new Task<List<Restaurant>> GetAll()
        {
            return await this._context.Restaurants.Include(x => x.MenuItems).ToListAsync();
        }

        public async new Task<Restaurant> GetById(int id)
        {
            return await this._context.Restaurants.Include(x => x.MenuItems).FirstOrDefaultAsync(x => x.Id == id);
        }


    }
}

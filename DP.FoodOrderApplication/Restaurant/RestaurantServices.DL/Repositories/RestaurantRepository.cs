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
    }
}

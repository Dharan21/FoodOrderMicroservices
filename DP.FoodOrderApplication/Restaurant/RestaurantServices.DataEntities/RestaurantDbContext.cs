using Microsoft.EntityFrameworkCore;
using RestaurantServices.DataEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantServices.DataEntities
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public RestaurantDbContext() { }
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }
    }
}

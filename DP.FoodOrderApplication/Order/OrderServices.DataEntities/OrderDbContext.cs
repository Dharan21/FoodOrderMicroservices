using Microsoft.EntityFrameworkCore;
using OrderServices.DataEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.DataEntities
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public OrderDbContext() { }
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }
    }
}

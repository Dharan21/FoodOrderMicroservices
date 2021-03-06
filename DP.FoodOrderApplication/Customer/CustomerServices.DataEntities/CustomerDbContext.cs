using CustomerServices.DataEntities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerServices.DataEntities
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public CustomerDbContext() { }
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }
    }
}

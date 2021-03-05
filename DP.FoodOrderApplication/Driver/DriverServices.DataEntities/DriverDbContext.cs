using DriverServices.DataEntities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriverServices.DataEntities
{
    public class DriverDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public DriverDbContext() { }
        public DriverDbContext(DbContextOptions<DriverDbContext> options) : base(options) { }
    }
}

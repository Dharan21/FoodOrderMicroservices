using APIAuthentication.DataEntities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAuthentication.DataEntities
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserDbContext() { }
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
    }
}

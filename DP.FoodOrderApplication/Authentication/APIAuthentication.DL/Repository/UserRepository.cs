using APIAuthentication.DataEntities;
using APIAuthentication.DataEntities.Entities;
using APIAuthentication.DL.Interfaces;
using Infrastructure.Repository.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAuthentication.DL.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly UserDbContext dbContext;

        public UserRepository(UserDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

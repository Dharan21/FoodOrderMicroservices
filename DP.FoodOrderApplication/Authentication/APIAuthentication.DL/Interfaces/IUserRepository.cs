using APIAuthentication.DataEntities.Entities;
using Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAuthentication.DL.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}

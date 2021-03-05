using CustomerServices.DataEntities.Entities;
using Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerServices.DL.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }
}

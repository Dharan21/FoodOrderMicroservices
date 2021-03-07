using Infrastructure.Repository.Interfaces;
using OrderServices.DataEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.DL.Interfaces
{
    public interface IRestaurantRepository : IGenericRepository<Restaurant>
    {
    }
}

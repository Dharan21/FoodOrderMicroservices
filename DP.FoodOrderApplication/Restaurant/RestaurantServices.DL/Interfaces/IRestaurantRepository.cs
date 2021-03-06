using Infrastructure.Repository.Interfaces;
using RestaurantServices.DataEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantServices.DL.Interfaces
{
    public interface IRestaurantRepository : IGenericRepository<Restaurant>
    {
    }
}

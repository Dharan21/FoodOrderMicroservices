using Infrastructure.Repository.Interfaces;
using RestaurantServices.DataEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantServices.DL.Interfaces
{
    public interface IMenuItemRepository : IGenericRepository<MenuItem>
    {
        Task<int> CreateMenuItem(MenuItem item);
    }
}

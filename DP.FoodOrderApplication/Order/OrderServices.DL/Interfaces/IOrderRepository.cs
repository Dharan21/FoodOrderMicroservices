using Infrastructure.Repository.Interfaces;
using OrderServices.DataEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderServices.DL.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<int> PlaceOrder(Order order);
    }
}

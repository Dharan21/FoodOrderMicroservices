using OrderServices.BusinessEntities.RequestModels;
using OrderServices.BusinessEntities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderServices.BL.Interfaces
{
    public interface IOrderManager
    {
        Task<List<OrderResponseModel>> GetAll();
        Task Add(OrderRequestModel order);
        Task AssignDriver(AssignDriverRequestModel model);
        Task Edit(OrderRequestModel order);
        Task Delete(int orderId);
        Task<List<OrderResponseModel>> GetByCustomer(int customerId);
        Task<List<OrderResponseModel>> GetByRestaurant(int restaurantId);
        Task<List<OrderResponseModel>> GetByRestaurant(int restaurantId, int driverId);
        Task<MonthlyReportResponseModel> GenerateMonthlyReport(int restaurantId, int month);
        Task<List<OrderResponseModel>> GetByDriver(int driverId);
    }
}

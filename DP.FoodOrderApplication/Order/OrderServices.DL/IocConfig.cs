using Microsoft.Extensions.DependencyInjection;
using OrderServices.DataEntities;
using OrderServices.DL.Interfaces;
using OrderServices.DL.Repositories;
using System;

namespace OrderServices.DL
{
    public static class IocConfig
    {
        public static void ConfigureServices(ref IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<OrderDbContext, OrderDbContext>();
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        }
    }
}

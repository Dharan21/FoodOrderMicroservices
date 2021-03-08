using Microsoft.Extensions.DependencyInjection;
using OrderServices.BL.Interfaces;
using OrderServices.BL.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.BL
{
    public static class IocConfig
    {
        public static void ConfigureServices(ref IServiceCollection services)
        {
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IDriverManager, DriverManager>();
            services.AddScoped<IRestaurantManager, RestaurantManager>();
            services.AddScoped<IMenuItemManager, MenuItemManager>();
            DL.IocConfig.ConfigureServices(ref services);
        }
    }
}

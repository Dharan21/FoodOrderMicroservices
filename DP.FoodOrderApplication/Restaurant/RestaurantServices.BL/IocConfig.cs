using Microsoft.Extensions.DependencyInjection;
using RestaurantServices.BL.Interfaces;
using RestaurantServices.BL.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantServices.BL
{
    public static class IocConfig
    {
        public static void ConfigureServices(ref IServiceCollection services)
        {
            services.AddScoped<IRestaurantManager, RestaurantManager>();
            services.AddScoped<IMenuItemManager, MenuItemManager>();
            DL.IocConfig.ConfigureServices(ref services);
        }
    }
}

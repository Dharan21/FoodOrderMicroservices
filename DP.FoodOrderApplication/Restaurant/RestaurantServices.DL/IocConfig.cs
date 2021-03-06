using Microsoft.Extensions.DependencyInjection;
using RestaurantServices.DataEntities;
using RestaurantServices.DL.Interfaces;
using RestaurantServices.DL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantServices.DL
{
    public static class IocConfig
    {
        public static void ConfigureServices(ref IServiceCollection services)
        {
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            services.AddScoped<RestaurantDbContext, RestaurantDbContext>();
        }
    }
}

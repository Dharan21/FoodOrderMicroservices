using DriverServices.DataEntities;
using DriverServices.DL.Interfaces;
using DriverServices.DL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriverServices.DL
{
    public static class IocConfig
    {
        public static void ConfigureServices(ref IServiceCollection services)
        {
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<DriverDbContext, DriverDbContext>();
        }
    }
}

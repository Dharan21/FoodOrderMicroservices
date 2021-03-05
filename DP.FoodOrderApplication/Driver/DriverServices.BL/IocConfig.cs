using DriverServices.BL.Interfaces;
using DriverServices.BL.Managers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriverServices.BL
{
    public static class IocConfig
    {
        public static void ConfigureServices(ref IServiceCollection services)
        {
            services.AddScoped<IDriverManager, DriverManager>();
            DL.IocConfig.ConfigureServices(ref services);
        }
    }
}

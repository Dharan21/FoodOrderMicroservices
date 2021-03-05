using CustomerServices.BL.Interfaces;
using CustomerServices.BL.Managers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerServices.BL
{
    public static class IocConfig
    {
        public static void ConfigureServices(ref IServiceCollection services)
        {
            services.AddScoped<ICustomerManager, CustomerManager>();
            DL.IocConfig.ConfigureServices(ref services);
        }
    }
}

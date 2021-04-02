using APIAuthentication.BL.Interfaces;
using APIAuthentication.BL.Manager;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace APIAuthentication.BL
{
    public static class IocConfig
    {
        public static void ConfigureServices(ref IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();
            DL.IocConfig.ConfigureServices(ref services);
        }
    }
}

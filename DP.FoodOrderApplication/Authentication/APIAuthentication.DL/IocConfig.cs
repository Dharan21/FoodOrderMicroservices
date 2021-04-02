using APIAuthentication.DataEntities;
using APIAuthentication.DL.Interfaces;
using APIAuthentication.DL.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace APIAuthentication.DL
{
    public static  class IocConfig
    {
        public static void ConfigureServices(ref IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<UserDbContext, UserDbContext>();
        }
    }
}

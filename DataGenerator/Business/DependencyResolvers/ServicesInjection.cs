using Business.Logging;
using DataAccess.Configurations;
using DataAccess.Context;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers
{
    public static class ServicesInjection
    {
        public static IServiceCollection AddSerilogService(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();
            IConfiguration configuration = provider.GetService<IConfiguration>();
            var log = Log.Logger.CreateLogger("BookStore", configuration.GetConnectionString("DefaultConnection"));
            services.AddSingleton<Serilog.ILogger>(log);

            return services;
        }

        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole<int>>(x =>
            {
                x.Password.RequireUppercase = false;
                x.Password.RequireLowercase = false;
                x.Password.RequiredLength = 6;
                x.Password.RequireNonAlphanumeric = false;

            }).AddEntityFrameworkStores<RDGContext>();
            return services;
        }

        public static IServiceCollection AddManagerService(this IServiceCollection services)
        {

            return services;
        }

        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();
            IConfiguration configuration = provider.GetService<IConfiguration>();
            services.AddScoped<SavingChangesInterceptor>();
            services.AddDbContext<RDGContext>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}

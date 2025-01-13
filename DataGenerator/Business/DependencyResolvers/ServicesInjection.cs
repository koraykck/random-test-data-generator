using Business.Logging;
using Business.ManagerServices.Abstracts;
using Business.ManagerServices.Concretes;
using Business.Strategy.Concretes;
using Business.Strategy.Interfaces;
using Business.Strategy;
using DataAccess.Configurations;
using DataAccess.Context;
using DataAccess.Repositories.Abstracts;
using DataAccess.Repositories.Concretes;
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
using Business.ManagerServices;

namespace Business.DependencyResolvers
{
    public static class ServicesInjection
    {
        public static IServiceCollection AddSerilogService(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();
            IConfiguration configuration = provider.GetService<IConfiguration>();
            var log = Log.Logger.CreateLogger("RDG", configuration.GetConnectionString("DefaultConnection"));
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
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IManager<>), typeof(BaseManager<>));
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAppUserManager, AppUserManager>();

            services.AddScoped<IRandomDataTypeManager, RandomDataTypeManager>();
            services.AddScoped<IRandomDataManager, RandomDataManager>();

            // Register the strategy factory
            services.AddSingleton<DataGeneratorStrategyFactory>();
            services.AddTransient<IntegerDataGenerator>();
            services.AddTransient<StringDataGenerator>();
            services.AddTransient<DateTimeDataGenerator>();
            services.AddTransient<BooleanDataGenerator>(); 
            services.AddTransient<GuidDataGenerator>();
            services.AddTransient<MailDataGenerator>();
            services.AddTransient<DbDataGenerator>();

            services.AddScoped<DataGeneratorService>();
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

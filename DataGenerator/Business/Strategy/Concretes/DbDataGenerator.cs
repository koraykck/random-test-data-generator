using Business.ManagerServices.Abstracts;
using Business.ManagerServices.DTOs;
using Business.Strategy.Interfaces;
using DataAccess.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Strategy.Concretes
{
    public class DbDataGenerator : IDataGeneratorStrategy
    {
        private readonly IServiceProvider _serviceProvider;
        public DbDataGenerator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public RandomDataDTO GenerateRandomData(Dictionary<string, object> parameters)
        {

            int typeId = (int)parameters["typeId"];
            using (var scope = _serviceProvider.CreateScope())
            {
                var _randomDataManager = scope.ServiceProvider.GetRequiredService<IRandomDataManager>();
                
                var result = _randomDataManager.GetOneRandomById(typeId);
                result.Wait();

                return result.Result;

            }
        }
    }
}

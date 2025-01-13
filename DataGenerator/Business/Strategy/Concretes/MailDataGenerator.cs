using Business.ManagerServices.Abstracts;
using Business.ManagerServices.Concretes;
using Business.ManagerServices.DTOs;
using Business.Strategy.Interfaces;
using DataAccess.Context;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Strategy.Concretes
{
    public class MailDataGenerator : IDataGeneratorStrategy
    {
        private readonly IServiceProvider _serviceProvider;
        public MailDataGenerator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public RandomDataDTO GenerateRandomData(Dictionary<string, object> parameters)
        {
            int typeId = (int)parameters["typeId"];
            using (var scope = _serviceProvider.CreateScope())
            {
                var _randomDataManager = scope.ServiceProvider.GetRequiredService<IRandomDataManager>();
                var _db = scope.ServiceProvider.GetRequiredService<RDGContext>();
                var lastNameTypeId = _db.RandomDataTypes.Where(x => x.Key == "last-name").Select(x => x.ObjectId).FirstOrDefault();
                var firstNameTypeId = _db.RandomDataTypes.Where(x => x.Key == "name").Select(x => x.ObjectId).FirstOrDefault();

                var nameResult = _randomDataManager.GetOneRandomById(lastNameTypeId);
                var lastNameResult = _randomDataManager.GetOneRandomById(firstNameTypeId);

                string mail = nameResult.Value + lastNameResult.Value[0];

                var result = _randomDataManager.GetOneRandomById(typeId);

                result.Value = mail.ToLower() + result.Value;
                return result;

            }
        }
    }
}

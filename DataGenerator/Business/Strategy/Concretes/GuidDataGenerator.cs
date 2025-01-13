using Business.ManagerServices.DTOs;
using Business.Strategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Strategy.Concretes
{
    public class GuidDataGenerator : IDataGeneratorStrategy
    {
        public RandomDataDTO GenerateRandomData(Dictionary<string, object> parameters)
        {
            var result = new RandomDataDTO
            {
                TypeKey = "guid",
                TypeId = 0,
                DependentValue = null,
                DependentValueId = null,
                Value  = Guid.NewGuid().ToString(),
            };


            return result;
        }
    }
}

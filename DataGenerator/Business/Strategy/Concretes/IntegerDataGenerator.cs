using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.ManagerServices.DTOs;
using Business.Strategy.Interfaces;

namespace Business.Strategy.Concretes
{
    public class IntegerDataGenerator : IDataGeneratorStrategy
    {
        private Random _random = new Random();

        public RandomDataDTO GenerateRandomData(Dictionary<string, object> parameters)
        {
            int min = (int)parameters["min"];
            int max = (int)parameters["max"];
            var result = new RandomDataDTO
            {
                TypeKey = "integer",
                TypeId = 0,
                DependentValue = null,
                DependentValueId = null,
                Value = _random.Next(min, max).ToString(),
            };
            return result;
        }
        
    }
}

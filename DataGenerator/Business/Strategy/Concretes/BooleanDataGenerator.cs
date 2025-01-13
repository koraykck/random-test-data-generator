using Business.ManagerServices.DTOs;
using Business.Strategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Strategy.Concretes
{
    public class BooleanDataGenerator : IDataGeneratorStrategy
    {
        private Random _random = new Random();

        public RandomDataDTO GenerateRandomData(Dictionary<string, object> parameters)
        {
            var randValue = _random.Next(0, 2) == 1;
            var result = new RandomDataDTO
            {
                TypeKey = "boolean",
                TypeId = 0,
                DependentValue = null,
                DependentValueId = null,
                Value = randValue.ToString(),
            };

            return result;
        }
    }
}

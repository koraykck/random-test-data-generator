using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.ManagerServices.DTOs;
using Business.Strategy.Interfaces;

namespace Business.Strategy.Concretes
{
    public class StringDataGenerator : IDataGeneratorStrategy
    {
        private Random _random = new Random();
     
        public RandomDataDTO GenerateRandomData(Dictionary<string, object> parameters)
        {
            int length = (int)parameters["length"];
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[_random.Next(chars.Length)];
            }

            var result = new RandomDataDTO
            {
                TypeKey = "string",
                TypeId = 0,
                DependentValue = null,
                DependentValueId = null,
                Value = new string(stringChars),
            };

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Strategy.Interfaces;

namespace Business.Strategy.Concretes
{
    public class IntegerDataGenerator : IDataGeneratorStrategy
    {
        private Random _random = new Random();

        public object GenerateRandomData(Dictionary<string, object> parameters)
        {
            int min = (int)parameters["min"];
            int max = (int)parameters["max"];

            return _random.Next(min, max);
        }
        
    }
}

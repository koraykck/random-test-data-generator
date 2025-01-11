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

        public object GenerateRandomData(Dictionary<string, object> parameters)
        {
            return _random.Next(0, 2) == 1; 
        }
    }
}

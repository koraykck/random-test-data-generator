using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Strategy.Interfaces;

namespace Business.Strategy
{
    public class DataGeneratorContext
    {
        private IDataGeneratorStrategy _strategy;

        public void SetStrategy(IDataGeneratorStrategy strategy)
        {
            _strategy = strategy;
        }

        public List<object> GenerateRandomData(int numberOfRecords, Dictionary<string, object> parameters)
        {
            List<object> data = new List<object>();
            for (int i = 0; i < numberOfRecords; i++)
            {
                data.Add(_strategy.GenerateRandomData(parameters));
            }
            return data;
        }
    }
}

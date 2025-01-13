using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.ManagerServices.DTOs;
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

        public List<RandomDataDTO> GenerateRandomData(int numberOfRecords, Dictionary<string, object> parameters)
        {
            List<RandomDataDTO> data = new List<RandomDataDTO>();
            for (int i = 0; i < numberOfRecords; i++)
            {

                data.Add(_strategy.GenerateRandomData(parameters));

            }
            return data;
        }
    }
}

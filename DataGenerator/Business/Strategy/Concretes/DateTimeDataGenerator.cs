using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Strategy.Interfaces;

namespace Business.Strategy.Concretes
{
    public class DateTimeDataGenerator : IDataGeneratorStrategy
    {
        private Random _random = new Random();
        
        public object GenerateRandomData(Dictionary<string, object> parameters)
        {
            DateTime start = (DateTime)parameters["start"];
            DateTime end = (DateTime)parameters["end"];
            TimeSpan timeSpan = end - start;
            int totalDays = (int)timeSpan.TotalDays;
            return start.AddDays(_random.Next(totalDays));
        }
    }
}

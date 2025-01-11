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
        public object GenerateRandomData(Dictionary<string, object> parameters)
        {
            return Guid.NewGuid(); // Yeni bir GUID oluşturur
        }
    }
}

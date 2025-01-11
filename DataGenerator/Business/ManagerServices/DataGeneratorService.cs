using Business.Strategy;
using Business.Strategy.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ManagerServices
{
    public class DataGeneratorService
    {
        private readonly DataGeneratorStrategyFactory _factory;

        public DataGeneratorService(DataGeneratorStrategyFactory factory)
        {
            _factory = factory;
            factory.RegisterStrategy("Integer", typeof(IntegerDataGenerator));
            factory.RegisterStrategy("String", typeof(StringDataGenerator));
            factory.RegisterStrategy("DateTime", typeof(DateTimeDataGenerator));
            factory.RegisterStrategy("Boolean", typeof(BooleanDataGenerator));
            factory.RegisterStrategy("Guid", typeof(GuidDataGenerator));
        }

        public List<object> GenerateData(string key, int numberOfRecords, Dictionary<string, object> parameters)
        {
            var strategy = _factory.GetStrategy(key);
            var context = new DataGeneratorContext();
            context.SetStrategy(strategy);
            return context.GenerateRandomData(numberOfRecords, parameters);
        }
    }
}

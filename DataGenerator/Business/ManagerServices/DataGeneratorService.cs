using Business.ManagerServices.DTOs;
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
            factory.RegisterStrategy("integer", typeof(IntegerDataGenerator));
            factory.RegisterStrategy("string", typeof(StringDataGenerator));
            factory.RegisterStrategy("datetime", typeof(DateTimeDataGenerator));
            factory.RegisterStrategy("boolean", typeof(BooleanDataGenerator));
            factory.RegisterStrategy("guid", typeof(GuidDataGenerator));
            factory.RegisterStrategy("mail", typeof(MailDataGenerator));
            factory.RegisterStrategy("db", typeof(DbDataGenerator));
        }

        public List<RandomDataDTO> GenerateData(string key, int numberOfRecords, Dictionary<string, object> parameters)
        {
            var strategy = _factory.GetStrategy(key);
            var context = new DataGeneratorContext();
            context.SetStrategy(strategy);
            return context.GenerateRandomData(numberOfRecords, parameters);
        }
    }
}

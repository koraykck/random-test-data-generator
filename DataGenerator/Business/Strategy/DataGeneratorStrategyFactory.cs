using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Strategy.Interfaces;

namespace Business.Strategy
{
    public class DataGeneratorStrategyFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<string, Type> _strategies;

        public DataGeneratorStrategyFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _strategies = new Dictionary<string, Type>();
        }

        public void RegisterStrategy(string key, Type strategyType)
        {
            _strategies[key] = strategyType;
        }

        public IDataGeneratorStrategy GetStrategy(string key)
        {
            if (_strategies.TryGetValue(key, out var strategyType))
            {
                return (IDataGeneratorStrategy)_serviceProvider.GetService(strategyType);
            }
            throw new ArgumentException($"No strategy found for key: {key}");
        }
    }
}

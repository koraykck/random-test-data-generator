using Business.ManagerServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Strategy.Interfaces
{
    public interface IDataGeneratorStrategy
    {
        RandomDataDTO GenerateRandomData(Dictionary<string, object> parameters);
    }
}

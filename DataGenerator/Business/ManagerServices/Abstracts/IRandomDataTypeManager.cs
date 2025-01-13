using Business.ManagerServices.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ManagerServices.Abstracts
{
    public interface IRandomDataTypeManager : IManager<RandomDataType>
    {
        Task<List<RandomDataTypeDTO>> GetAllTypes();
        Task<List<DetailedTypesDTO>> GetTypesByIds(List<int> ids);

    }
}

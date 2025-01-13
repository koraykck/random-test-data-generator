using Business.ManagerServices.Abstracts;
using Business.ManagerServices.DTOs;
using DataAccess.Context;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ManagerServices.Concretes
{
    public class RandomDataTypeManager : BaseManager<RandomDataType>, IRandomDataTypeManager
    {
        public RandomDataTypeManager(RDGContext db) : base(db)
        {
        }

        public async Task<List<RandomDataTypeDTO>> GetAllTypes()
        {
            var result =  _db.RandomDataTypes.Select(x => new RandomDataTypeDTO
            {
                TypeId = x.ObjectId,
                Description = x.Description,
                Key = x.Key,
                Name = x.Name,
            }).ToList();

            return result;
        }

        public async Task<List<DetailedTypesDTO>> GetTypesByIds(List<int> ids)
        {
            var result = _db.RandomDataTypes.Where(x=> ids.Contains(x.ObjectId)).Select(x => new DetailedTypesDTO
            {
                TypeId = x.ObjectId,
                GeneratorKey = x.GeneratorType,
                TypeKey = x.Key,
            }).ToList();

            return result;
        }
    }
}

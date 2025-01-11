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
    public class RandomDataManager : BaseManager<RandomData>, IRandomDataManager
    {
        public RandomDataManager(RDGContext db) : base(db)
        {
        }

        public async Task<bool> AddRangeRandomData(List<RandomDataDTO> list)
        {
            var model = list.Select(x=> new RandomData
            {
                TypeId = x.TypeId,
                Value = x.Value,
            }).ToList();
            _db.RandomDatas.AddRange(model);
            if(_db.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }
    }
}

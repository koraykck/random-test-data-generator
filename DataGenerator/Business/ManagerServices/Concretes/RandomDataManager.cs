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

        public async Task<RandomDataDTO> GetOneRandomById(int typeId)
        {
            var count = _db.RandomDatas.Where(x=> x.TypeId == typeId).Count();
            var randomIndex = new Random().Next(count);

            var randomRecord = _db.RandomDatas
                .Where(x => x.TypeId == typeId)
                .Skip(randomIndex)
                .Take(1)
                .Select(x=> new RandomDataDTO
                {
                     Value = x.Value,
                     TypeId = x.TypeId,
                })
                .FirstOrDefault();

            return randomRecord;
        }

        public async Task<List<RandomDataDTO>> GetRandomlyById(int numberOfRecords, int typeId)
        {
            
            List<RandomDataDTO> randomRecords  = _db.RandomDatas
                              .Where(x => x.TypeId == typeId)
                              .OrderBy(x => Guid.NewGuid())
                              .Take(numberOfRecords)
                              .Select(x => new RandomDataDTO
                              {
                                  TypeId = x.TypeId,
                                  Value = x.Value,
                              })
                              .ToList();
            
            return randomRecords;
        }

        
        public async Task<List<RandomDataDTO>> GetRandomlyByIds(int numberOfRecords, List<int> typeIds)
        {
            
            List<RandomDataDTO> randomRecords = new List<RandomDataDTO>();

            foreach (var type in typeIds) {
                var result = await this.GetRandomlyById(numberOfRecords, type);

                randomRecords = randomRecords.Concat(result).ToList();
            }
            return randomRecords;
        }
    }
}

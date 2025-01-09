using Business.ManagerServices.Abstracts;
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
    }
}

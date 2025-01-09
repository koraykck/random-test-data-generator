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
    public class RandomDataTypeManager : BaseManager<RandomDataType>, IRandomDataTypeManager
    {
        public RandomDataTypeManager(RDGContext db) : base(db)
        {
        }
    }
}

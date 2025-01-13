using Business.ManagerServices.Abstracts;
using DataAccess.Context;
using Domain.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ManagerServices.Concretes
{
    public class BaseManager<T> : IManager<T> where T : class,IEntity
    {
        public RDGContext _db;
        public BaseManager(RDGContext db)
        {
            _db = db;
        }
    }
}

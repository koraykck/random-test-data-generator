using DataAccess.Context;
using DataAccess.Repositories.Abstracts;
using Domain.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        RDGContext _db;
        public BaseRepository(RDGContext db)
        {
            _db = db;
        }
    }
}

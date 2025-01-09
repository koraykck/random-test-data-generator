using Business.ManagerServices.Abstracts;
using DataAccess.Context;
using DataAccess.Repositories.Abstracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ManagerServices.Concretes
{
    public class AppUserManager : BaseManager<AppUser>, IAppUserManager
    {

        IAppUserRepository _apRep;

        public AppUserManager(RDGContext db, IAppUserRepository apRep) : base(db)
        {
            _apRep = apRep;
        }

        public async Task<bool> CreateUserAsync(AppUser item)
        {
            //todo : BL yazılır

            return await _apRep.AddUser(item);
        }


    }
}

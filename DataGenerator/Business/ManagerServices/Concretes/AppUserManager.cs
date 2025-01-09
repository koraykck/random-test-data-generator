using Business.ManagerServices.Abstracts;
using Business.ManagerServices.DTOs;
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

        public async Task<bool> CreateUserAsync(RegisterDTO item)
        {
            var request = new AppUser
            {
                UserName = item.Username,
                Email = item.Email,
                PasswordHash = item.Password,
                NameSurname = item.NameSurname,
            };

            return await _apRep.AddUser(request);
        }

        public Task<bool> SignInUser(string username, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return _apRep.SignUserIn(username,password, isPersistent, lockoutOnFailure);
        }

        public Task<bool> SignOutUser()
        {
            return _apRep.SignOut();
        }
    }
}

using DataAccess.Context;
using DataAccess.Repositories.Abstracts;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concretes
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        UserManager<AppUser> _userManager;

        public AppUserRepository(RDGContext db, UserManager<AppUser> userManager) : base(db)
        {

            _userManager = userManager;
        }
        public async Task<bool> AddUser(AppUser item)
        {
            IdentityResult result = await _userManager.CreateAsync(item, item.PasswordHash);

            if (result.Succeeded) return true;
            //List<IdentityError> errors = new List<IdentityError>();
            //foreach (IdentityError error in result.Errors)
            //{
            //    errors.Add(error);
            //}
            return false;

        }
    }
}

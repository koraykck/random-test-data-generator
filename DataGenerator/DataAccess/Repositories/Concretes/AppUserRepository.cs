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
        SignInManager<AppUser> _signInManager;

        public AppUserRepository(RDGContext db, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(db)
        {

            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> AddUser(AppUser item)
        {
            IdentityResult result = await _userManager.CreateAsync(item, item.PasswordHash);

            if (result.Succeeded) return true;
          
            return false;

        }

        public async Task<bool> SignUserIn(string username, string password, bool isPersistent, bool lockoutOnFailure)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(username, password, isPersistent, lockoutOnFailure);

            if (result.Succeeded) return true;
           
            return false;

        }
        public async Task<bool> SignOut()
        {
            await _signInManager.SignOutAsync();
            return true;

        }

        
    }
}

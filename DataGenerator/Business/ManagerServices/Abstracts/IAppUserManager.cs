using Business.ManagerServices.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ManagerServices.Abstracts
{
    public interface IAppUserManager : IManager<AppUser>
    {
        Task<bool> CreateUserAsync(RegisterDTO item);
        Task<bool> SignInUser(string username, string password, bool isPersistent, bool lockoutOnFailure);
        Task<bool> SignOutUser();
    }
}

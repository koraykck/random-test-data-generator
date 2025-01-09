using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstracts
{
    public interface IAppUserRepository : IRepository<AppUser>
    {

        Task<bool> AddUser(AppUser item);
        Task<bool> SignUserIn(string username, string password, bool isPersistent, bool lockoutOnFailure );
        Task<bool> SignOut( );
    }
}

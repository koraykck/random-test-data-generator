using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class RDGContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public RDGContext(DbContextOptions<RDGContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>().Ignore(x => x.ObjectId);

        }

        DbSet<AppUser> AppUsers { get; set; }
        DbSet<AppUserProfile> AppUserProfiles { get; set; }
    }
}

using DataAccess.Configurations;
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
        private readonly SavingChangesInterceptor _savingChangesInterceptor;

        public RDGContext(DbContextOptions<RDGContext> options, SavingChangesInterceptor savingChangesInterceptor) : base(options)
        {
            _savingChangesInterceptor = savingChangesInterceptor;

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<RandomData> RandomDatas { get; set; }
        public DbSet<RandomDataType> RandomDataTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.AddGlobalFilter();
            builder.Entity<AppUser>().Ignore(x => x.ObjectId);
            builder.ApplyConfiguration(new RandomDataTypeConfiguration());

            var cascadeFKs = builder.Model.GetEntityTypes()
               .SelectMany(t => t.GetForeignKeys())
               .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            base.OnModelCreating(builder);

        }
     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_savingChangesInterceptor);
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
    }
}

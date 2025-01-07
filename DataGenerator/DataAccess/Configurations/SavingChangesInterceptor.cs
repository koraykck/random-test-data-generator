using Domain.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Interfaces;

namespace DataAccess.Configurations
{
    public class SavingChangesInterceptor : SaveChangesInterceptor
    {
        private readonly ILogger<SavingChangesInterceptor> _logger;
        public SavingChangesInterceptor(ILogger<SavingChangesInterceptor> logger)
        {
            _logger = logger;
        }
        #region SavingChanges
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            OperationOnEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }
        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            OperationOnEntities(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }
        #endregion

        #region SavedChanges
        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            _logger.LogInformation(1, eventData.EventIdCode, result);
            return base.SavedChanges(eventData, result);
        }
        public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation(1, eventData.EventIdCode, result);
            return await base.SavedChangesAsync(eventData, result, cancellationToken);
        }
        #endregion

        #region SaveChangesFailed
        public override void SaveChangesFailed(DbContextErrorEventData eventData)
        {
            _logger.LogError(1, eventData.Exception.Message);
            base.SaveChangesFailed(eventData);
        }
        public override async Task SaveChangesFailedAsync(DbContextErrorEventData eventData, CancellationToken cancellationToken = default)
        {
            _logger.LogError(1, eventData.Exception.Message);
            await base.SaveChangesFailedAsync(eventData, cancellationToken);
        }
        #endregion

        #region Operations
        private void OperationOnEntities(DbContext context)
        {
            context.ChangeTracker.DetectChanges();

            // base entity with int id operations
            foreach (var entry in context.ChangeTracker.Entries<IEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.Entity.IsDeleted = true;
                        entry.Entity.DeletedDate = DateTime.Now;
                        //entry.Entity.DeletedBy = 0;
                        break;
                    case EntityState.Modified:
                        if (entry.Entity.IsDeleted)
                        {
                            entry.Entity.DeletedDate = DateTime.Now;
                            //entry.Entity.DeletedBy = 0;
                        }
                        entry.Entity.UpdatedDate = DateTime.Now;
                        //entry.Entity.UpdatedBy = 0;
                        break;
                    case EntityState.Added:
                        entry.Entity.IsDeleted = false;
                        entry.Entity.CreatedDate = DateTime.Now;
                        //entry.Entity.CreatedBy = 0;
                        break;
                }
            }


        }
        #endregion
    }
}

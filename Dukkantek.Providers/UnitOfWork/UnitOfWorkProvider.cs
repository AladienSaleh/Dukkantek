using Dukkantek.Data.Models;
using Dukkantek.Domain.Contracts.Provider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek.Providers.UnitOfWork
{
    public class UnitOfWorkProvider : IUnitOfWorkProvider
    {
        #region Private members
        private readonly DukkantekApiDbContext _dbContext;
        private IDbContextTransaction _transaction;
        #endregion

        #region Constructor
        public UnitOfWorkProvider(DukkantekApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Public methods
        public async Task BeginTransaction(IsolationLevel? isolationLevel = null)
        {
            if (_transaction == null)
            {
                if (!isolationLevel.HasValue)
                {
                    _transaction = await _dbContext.Database.BeginTransactionAsync();
                }
                else
                {
                    _transaction = await _dbContext.Database.BeginTransactionAsync(isolationLevel.Value);
                }
            }
        }

        public async Task Commit()
        {
            if (_transaction != null)
            {
                await SaveChangesAsync();
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollBack()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
                DetachAllEntities(_dbContext);
            }
        }

        public async Task ExecuteStrategy(Func<Task> p)
        {
            var excutionStratigy = _dbContext.Database.CreateExecutionStrategy();
            await excutionStratigy.ExecuteAsync(async () =>
            {
                await p.Invoke();
            });
        }
        #endregion

        #region Private methods
        private async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        private void DetachAllEntities(DukkantekApiDbContext db)
        {
            var changedEntriesCopy = db.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
        #endregion
    }
}

using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities;

namespace WhiskyMan.Repositories.Interfaces
{
    public interface IDataContextWrapper
    {
        IQueryable<User> Users { get; }
        IQueryable<Bottle> Bottles { get; }
        IQueryable<BottleDescription> BottleDescriptions { get; }
        IQueryable<Transaction> Transactions { get; }

        ValueTask<EntityEntry<TEntity>> AddEntityAsync<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> AddEntity<TEntity>(TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}

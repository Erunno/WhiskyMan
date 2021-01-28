using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities;
using WhiskyMan.Entities.Auth;
using WhiskyMan.Repositories.Interfaces;

namespace WhiskyMan.Repositories
{
   public class DataContextWrapper : IDataContextWrapper
    {
        private readonly DataContext context;

        public DataContextWrapper(
            DataContext context)
        {
            this.context = context;
        }

        public IQueryable<User> Users => context.Users;
        public IQueryable<Bottle> Bottles => context.Bottles;
        public IQueryable<BottleDescription> BottleDescriptions => context.BottleDescriptions;
        public IQueryable<Transaction> Transactions => context.Transactions;
        public IQueryable<Tag> Tags => context.Tags;
        public IQueryable<SpecialPrice> SpecialPrices => context.SpecialPrices;

        public EntityEntry<TEntity> AddEntity<TEntity>(TEntity entity) where TEntity : class
            => context.Add(entity);

        public ValueTask<EntityEntry<TEntity>> AddEntityAsync<TEntity>(TEntity entity) where TEntity : class 
            => context.AddAsync(entity);

        public int SaveChanges() => context.SaveChanges();

        public Task<int> SaveChangesAsync() => context.SaveChangesAsync();

    }
}

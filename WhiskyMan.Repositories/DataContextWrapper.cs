using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities;
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
        
        public ValueTask<EntityEntry<TEntity>> AddEntityAsync<TEntity>(TEntity user) where TEntity : class 
            => context.AddAsync<TEntity>(user);

        public Task<int> SaveChangesAsync() => context.SaveChangesAsync();

    }
}

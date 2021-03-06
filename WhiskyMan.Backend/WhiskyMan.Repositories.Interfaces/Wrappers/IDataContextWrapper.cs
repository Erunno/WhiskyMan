﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities;
using WhiskyMan.Entities.Auth;

namespace WhiskyMan.Repositories.Interfaces
{
    public interface IDataContextWrapper
    {
        IQueryable<User> Users { get; }
        IQueryable<Bottle> Bottles { get; }
        IQueryable<BottleDescription> BottleDescriptions { get; }
        IQueryable<Transaction> Transactions { get; }
        IQueryable<Tag> Tags { get; }
        IQueryable<SpecialPrice> SpecialPrices { get; }

        DatabaseFacade Database { get; }

        ValueTask<EntityEntry<TEntity>> AddEntityAsync<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> AddEntity<TEntity>(TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}

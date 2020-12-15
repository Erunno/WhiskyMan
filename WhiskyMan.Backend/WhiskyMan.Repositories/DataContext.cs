using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WhiskyMan.Entities;
using WhiskyMan.Repositories.Interfaces;

namespace WhiskyMan.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bottle> Bottles { get; set; }
        public DbSet<BottleDescription> BottleDescriptions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        
    }
}

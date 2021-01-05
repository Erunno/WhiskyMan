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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(u => u.Bottles)
                .WithMany(b => b.Owners)
                .UsingEntity<Ownership>(
                    o => o.HasOne(o => o.Bottle).WithMany(u => u.Ownerships),
                    o => o.HasOne(o => o.Owner).WithMany(b => b.Ownerships)
                );

            builder.Entity<SpecialPrice>().HasKey(sp => new { sp.BottleId, sp.UserId });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bottle> Bottles { get; set; }
        public DbSet<BottleDescription> BottleDescriptions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<SpecialPrice> SpecialPrices { get; set; }
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WhiskyMan.Entities;
using WhiskyMan.Entities.Auth;
using WhiskyMan.Repositories.Interfaces;

namespace WhiskyMan.Repositories
{
    public class DataContext 
        : IdentityDbContext<
            User,
            Role,
            long,
            IdentityUserClaim<long>,
            UserRole,
            IdentityUserLogin<long>,
            IdentityRoleClaim<long>,
            IdentityUserToken<long>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasMany(u => u.Bottles)
                .WithMany(b => b.Owners)
                .UsingEntity<Ownership>(
                    o => o.HasOne(o => o.Bottle).WithMany(u => u.Ownerships),
                    o => o.HasOne(o => o.Owner).WithMany(b => b.Ownerships)
                );

            builder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(b => b.Users)
                .UsingEntity<UserRole>(
                    o => o.HasOne(o => o.Role).WithMany(u => u.UserRoles),
                    o => o.HasOne(o => o.User).WithMany(b => b.UserRoles)
                );

            builder.Entity<SpecialPrice>().HasKey(sp => new { sp.BottleId, sp.UserId });
        }

        // roles and users are in parent class

        public DbSet<Bottle> Bottles { get; set; }
        public DbSet<BottleDescription> BottleDescriptions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<SpecialPrice> SpecialPrices { get; set; }
    }
}
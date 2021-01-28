using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WhiskyMan.Entities;
using WhiskyMan.Entities.Auth;
using WhiskyMan.Repositories;

namespace WhiskyMan.DatabaseSeedApp
{
    class Setup
    {
        public static DataContext GetSqliteDataContext(string pathToSqliteDb)
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlite($"Data Source={pathToSqliteDb}");

            return new DataContext(builder.Options);
        }

        public static (UserManager<User>, RoleManager<Role>) GetUserAndRoleManager(DataContext context)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton(context);
            services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
                .AddRoles<Role>()
                .AddRoleManager<RoleManager<Role>>()
                .AddSignInManager<SignInManager<User>>()
                .AddRoleValidator<RoleValidator<Role>>()
                .AddEntityFrameworkStores<DataContext>();

            var serviceProvider = services.BuildServiceProvider();

            return (
                serviceProvider.GetService<UserManager<User>>(),
                serviceProvider.GetService<RoleManager<Role>>()
                );
        }

        /// <summary>
        /// !!!!! This method deletes DbSets in passed context !!!!!!
        /// !!! Use it wisely !!!
        /// </summary>
        public static void ClearDatabase(DataContext context)
        {
            context.Transactions
                .RemoveRange(context.Transactions);
            Console.WriteLine("  ... transactions deleted");

            context.SpecialPrices
                .RemoveRange(context.SpecialPrices);
            Console.WriteLine("  ... special prices deleted");

            context.Bottles
                .RemoveRange(context.Bottles);
            Console.WriteLine("  ... bottles deleted");

            context.BottleDescriptions
                .RemoveRange(context.BottleDescriptions);
            Console.WriteLine("  ... bottle descriptions deleted");

            context.Tags
                .RemoveRange(context.Tags);
            Console.WriteLine("  ... tags deleted");

            context.Users
                .RemoveRange(context.Users);
            Console.WriteLine("  ... users deleted");

            context.Roles
                .RemoveRange(context.Roles);
            Console.WriteLine("  ... roles deleted");

            context.SaveChanges();
        }
    }
}

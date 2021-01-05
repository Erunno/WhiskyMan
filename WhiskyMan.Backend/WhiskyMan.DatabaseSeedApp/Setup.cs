using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WhiskyMan.Entities;
using WhiskyMan.Repositories;

namespace WhiskyMan.DatabaseSeedApp
{
    class Setup
    {
        public static DataContext GetSqliteDataContext()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlite($"Data Source={Path.Combine("..", "..", "..", "..", "WhiskyMan.API", "whiskyMan.db")}");

            return new DataContext(builder.Options);
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

            context.SaveChanges();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;

namespace WhiskyMan.DatabaseSeedApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Opening database ...");
            var context = Setup.GetSqliteDataContext();
            Console.WriteLine("Done.\n");


            Console.WriteLine("Clearing old data ...");
            Setup.ClearDatabase(context);
            Console.WriteLine("Done.\n");


            Console.WriteLine("Filling up database ...");
            FillUp.Run(context);
            Console.WriteLine("Done.\n");
        }
    }
}

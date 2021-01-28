using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using WhiskyMan.Entities.Auth;

namespace WhiskyMan.DatabaseSeedApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool userInputIsOk = CheckInputAndPromptUser(args);

            if (!userInputIsOk)
                return;

            RunDatabaseSeeding(pathToSqliteFile: args[0]);
        }

        private static void RunDatabaseSeeding(string pathToSqliteFile)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Opening database ...");
            var context = Setup.GetSqliteDataContext(pathToSqliteFile);
            var userManger = Setup.GetUserManager(context);
            Console.WriteLine("Done.\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Clearing old data ...");
            Setup.ClearDatabase(context);
            Console.WriteLine("Done.\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Filling up database ...");
            FillUp.Run(context, userManger);
            Console.WriteLine("Done.\n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static bool CheckInputAndPromptUser(string[] args)
        {
            if (args.Length != 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Program expects path to SQLite database file");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }

            var pathToSqliteFile = args[0];

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("You are about to delete content of SQLite database in file:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($" >> {pathToSqliteFile}");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Do you wish to proceed? ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("(y/n): ");

            string answer = Console.ReadLine().ToLower();
            if (answer != "y")
                return false;

            return true;
        }
    }
}

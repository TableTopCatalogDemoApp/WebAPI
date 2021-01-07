using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TableTopCatalogDemoApp.Data.Design.DataSeed;

namespace TableTopCatalogDemoApp.Data.Design
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = args.Any() ?
                args[0] :
                TableTopDataContextFactory.DefaultConnectionString;

            Console.WriteLine($"Connection string: {connectionString}");

            using (var context = new TableTopDataContextFactory().CreateDbContext(new[] {connectionString}))
            {
                Console.WriteLine("Migrations started.");
                context.Database.Migrate();
                Console.WriteLine("Migrations finished.");

                var dataSeedOrchestrator = new DataSeedOrchestrator(context);

                Console.WriteLine("Seeding preparing.");
                dataSeedOrchestrator.PrepareDatabase();
                Console.WriteLine("Seeding prepared.");

                Console.WriteLine("Seeding started.");
                dataSeedOrchestrator.ApplyAll();
                Console.WriteLine("Seeding finished.");
            }

            Console.WriteLine("All done.");
        }
    }
}

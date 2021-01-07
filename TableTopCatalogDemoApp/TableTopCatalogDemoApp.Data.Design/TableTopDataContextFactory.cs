using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TableTopCatalogDemoApp.Data.Design
{
    public class TableTopDataContextFactory : IDesignTimeDbContextFactory<TableTopDataContext>
    {
        public const string DefaultConnectionString =
            "Server=(localdb)\\mssqllocaldb;Database=TableTopData-Design";

        public TableTopDataContext CreateDbContext(string[] args)
        {
            var connectionString = args.Any() ?
                args[0] ?? DefaultConnectionString :
                DefaultConnectionString;

            var optionsBuilder = new DbContextOptionsBuilder<TableTopDataContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new TableTopDataContext(optionsBuilder.Options);
        }
    }
}

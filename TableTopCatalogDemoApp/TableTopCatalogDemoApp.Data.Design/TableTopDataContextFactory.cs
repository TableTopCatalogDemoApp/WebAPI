using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TableTopCatalogDemoApp.Data.Design
{
    public class TableTopDataContextFactory : IDesignTimeDbContextFactory<TableTopDataContext>
    {
        private readonly string _defaultConnectionString =
            "Server=(localdb)\\mssqllocaldb;Database=TableTopData-Design";

        public TableTopDataContext CreateDbContext(string[] args)
        {
            var connectionString = args.Any() ?
                args[0] ?? _defaultConnectionString :
                _defaultConnectionString;

            var optionsBuilder = new DbContextOptionsBuilder<TableTopDataContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new TableTopDataContext(optionsBuilder.Options);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TableTopCatalogDemoApp.Data.Entities;

namespace TableTopCatalogDemoApp.Data
{
    public class TableTopDataContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        public TableTopDataContext(DbContextOptions<TableTopDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMember>()
                .HasKey(x => new {x.PersonId, x.RoleId});

            base.OnModelCreating(modelBuilder);
        }
    }
}

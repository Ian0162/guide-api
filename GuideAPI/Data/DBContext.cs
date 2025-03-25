using GuideAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GuideAPI.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options): base(options) { }

        public DbSet<Department> departments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(DBContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.ConfigureWarnings(warnings => warnings.Log(RelationalEventId.PendingModelChangesWarning));

        }

    }
}

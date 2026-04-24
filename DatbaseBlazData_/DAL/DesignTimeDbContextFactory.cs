using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DatbaseBlazData_.DAL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DbInputContext>
    {
        public DbInputContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbInputContext>();
            // Design-time connection string for migrations. Development only: trust the server certificate.
            optionsBuilder.UseSqlServer("Server=LPTDCS001\\SQLEXPRESS;Database=InputDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

            return new DbInputContext(optionsBuilder.Options);
        }
    }
}

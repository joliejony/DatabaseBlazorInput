using Microsoft.EntityFrameworkCore;
using DatabaseBlazorInput.Data.Data;

namespace DatabaseBlazorInput.Data.DAL;

// DAL-level DbContext. This defaults to a local SQLite database file `database.db` when
// no options are configured. You can still register this context in a host with
// `services.AddDbContext<AppDbContext>(...)` to provide a different connection string.
public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ExcelRow> ExcelRows { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Default to a local SQLite file named database.db in the working directory
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DatabaseBlazorInput.Data.Data;

public static class MigrationExtensions
{
    /// <summary>
    /// Applies EF Core migrations for the specified DbContext type. If migrations cannot be applied
    /// this will fall back to EnsureCreated to create the schema from the model.
    /// Call this from your host `Program.cs` after building the app: `app.ApplyDatabaseMigrations<TContext>();`
    /// </summary>
    public static WebApplication ApplyDatabaseMigrations<TContext>(this WebApplication app)
        where TContext : DbContext
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var db = services.GetRequiredService<TContext>();
            // Try to apply migrations (recommended)
            db.Database.Migrate();
        }
        catch (Exception)
        {
            // If migration application fails (for example migrations not added), try EnsureCreated
            try
            {
                var db = services.GetRequiredService<TContext>();
                db.Database.EnsureCreated();
            }
            catch
            {
                // swallow to avoid crashing the host startup; host can log or rethrow as desired
            }
        }

        return app;
    }

    /// <summary>
    /// Convenience overload for AppDbContext
    /// </summary>
    public static WebApplication ApplyAppDbMigrations(this WebApplication app)
    {
        return app.ApplyDatabaseMigrations<AppDbContext>();
    }
}

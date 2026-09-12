using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace latiendahn.Modules.Sample.Infrastructure.Persistence;

/// <summary>Fabrica en design-time para 'dotnet ef migrations add ...'. No se usa en runtime.</summary>
public sealed class SampleDbContextFactory : IDesignTimeDbContextFactory<SampleDbContext>
{
    public SampleDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<SampleDbContext>()
            .UseNpgsql(
                "Host=localhost;Port=5432;Database=latiendahn;Username=postgres;Password=postgres",
                b => b.MigrationsHistoryTable("__ef_migrations_history", "sample"))
            .Options;
        return new SampleDbContext(options);
    }
}
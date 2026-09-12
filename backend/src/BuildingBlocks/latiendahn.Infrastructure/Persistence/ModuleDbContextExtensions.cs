using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace latiendahn.Infrastructure.Persistence;

public static class ModuleDbContextExtensions
{
    /// <summary>Registra el DbContext de un modulo apuntando a Postgres, con su tabla de historial de migraciones en su schema.</summary>
    public static IServiceCollection AddModuleDbContext<TContext>(
        this IServiceCollection services, string connectionString, string schema)
        where TContext : ModuleDbContext
    {
        services.AddDbContext<TContext>(options =>
            options.UseNpgsql(connectionString, npgsql =>
                npgsql.MigrationsHistoryTable("__ef_migrations_history", schema)));
        return services;
    }
}
using Microsoft.EntityFrameworkCore;
using latiendahn.BuildingBlocks.Persistence;

namespace latiendahn.Infrastructure.Persistence;

/// <summary>
/// DbContext base del que hereda cada modulo. Fija un schema propio por modulo (aislamiento de datos)
/// e implementa IUnitOfWork via el SaveChangesAsync de EF.
/// </summary>
public abstract class ModuleDbContext : DbContext, IUnitOfWork
{
    private readonly string _schema;

    protected ModuleDbContext(DbContextOptions options, string schema) : base(options) => _schema = schema;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(_schema);
        base.OnModelCreating(modelBuilder);
    }
}
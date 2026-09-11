using Microsoft.EntityFrameworkCore;
using latiendahn.Infrastructure.Persistence;
using latiendahn.Modules.Sample.Application.Abstractions;
using latiendahn.Modules.Sample.Domain;

namespace latiendahn.Modules.Sample.Infrastructure.Persistence;

public sealed class SampleDbContext : ModuleDbContext, ISampleUnitOfWork
{
    public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options, "sample") { }

    public DbSet<SampleItem> Samples => Set<SampleItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SampleDbContext).Assembly);
    }
}
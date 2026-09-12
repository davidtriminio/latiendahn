using Microsoft.EntityFrameworkCore;
using latiendahn.Modules.Sample.Application.Abstractions;
using latiendahn.Modules.Sample.Domain;

namespace latiendahn.Modules.Sample.Infrastructure.Persistence;

internal sealed class SampleRepository : ISampleRepository
{
    private readonly SampleDbContext _db;

    public SampleRepository(SampleDbContext db) => _db = db;

    public Task<SampleItem?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        _db.Samples.FirstOrDefaultAsync(x => x.Id == id, ct);

    public Task<bool> NameExistsAsync(string name, CancellationToken ct = default) =>
        _db.Samples.AnyAsync(x => x.Name == name, ct);

    public async Task<IReadOnlyList<SampleItem>> ListAsync(int page, int pageSize, CancellationToken ct = default) =>
        await _db.Samples.AsNoTracking()
            .OrderBy(x => x.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);

    public Task<int> CountAsync(CancellationToken ct = default) => _db.Samples.CountAsync(ct);

    public void Add(SampleItem item) => _db.Samples.Add(item);
}
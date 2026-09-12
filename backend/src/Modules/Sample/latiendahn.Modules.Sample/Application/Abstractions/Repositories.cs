using latiendahn.BuildingBlocks.Persistence;
using latiendahn.Modules.Sample.Domain;

namespace latiendahn.Modules.Sample.Application.Abstractions;

public interface ISampleUnitOfWork : IUnitOfWork;

public interface ISampleRepository
{
    Task<SampleItem?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<bool> NameExistsAsync(string name, CancellationToken ct = default);
    Task<IReadOnlyList<SampleItem>> ListAsync(int page, int pageSize, CancellationToken ct = default);
    Task<int> CountAsync(CancellationToken ct = default);
    void Add(SampleItem item);
}
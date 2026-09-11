using latiendahn.BuildingBlocks.Pagination;
using latiendahn.BuildingBlocks.Results;
using latiendahn.Modules.Sample.Application.Abstractions;
using latiendahn.Modules.Sample.Application.Contracts;
using latiendahn.Modules.Sample.Domain;

namespace latiendahn.Modules.Sample.Application.Services;

/// <summary>Casos de uso de lectura (paginados, solo proyeccion).</summary>
public sealed class SampleQueryService
{
    private readonly ISampleRepository _repository;

    public SampleQueryService(ISampleRepository repository) => _repository = repository;

    public async Task<PagedResult<SampleResponse>> ListAsync(int page, int pageSize, CancellationToken ct = default)
    {
        page = page < 1 ? 1 : page;
        pageSize = pageSize is < 1 or > 100 ? 20 : pageSize;

        var items = await _repository.ListAsync(page, pageSize, ct);
        var total = await _repository.CountAsync(ct);
        return new PagedResult<SampleResponse>(items.Select(Map).ToList(), page, pageSize, total);
    }

    public async Task<Result<SampleResponse>> GetAsync(Guid id, CancellationToken ct = default)
    {
        var item = await _repository.GetByIdAsync(id, ct);
        return item is null ? SampleErrors.NotFound : Map(item);
    }

    private static SampleResponse Map(SampleItem i) => new(i.Id, i.Name, i.Description, i.CreatedOn);
}
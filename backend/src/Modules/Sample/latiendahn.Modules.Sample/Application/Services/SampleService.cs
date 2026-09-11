using latiendahn.BuildingBlocks.Results;
using latiendahn.Modules.Sample.Application.Abstractions;
using latiendahn.Modules.Sample.Application.Contracts;
using latiendahn.Modules.Sample.Domain;

namespace latiendahn.Modules.Sample.Application.Services;

/// <summary>Casos de uso de escritura. Devuelven Result para forzar el manejo del fallo de dominio.</summary>
public sealed class SampleService
{
    private readonly ISampleRepository _repository;
    private readonly ISampleUnitOfWork _unitOfWork;
    private readonly TimeProvider _clock;

    public SampleService(ISampleRepository repository, ISampleUnitOfWork unitOfWork, TimeProvider clock)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _clock = clock;
    }

    public async Task<Result<CreatedResource>> CreateAsync(CreateSampleRequest request, CancellationToken ct = default)
    {
        if (await _repository.NameExistsAsync(request.Name.Trim(), ct))
            return SampleErrors.NameInUse(request.Name);

        var item = SampleItem.Create(request.Name, request.Description, _clock.GetUtcNow());
        _repository.Add(item);
        await _unitOfWork.SaveChangesAsync(ct);
        return new CreatedResource(item.Id);
    }

    public async Task<Result> UpdateAsync(Guid id, UpdateSampleRequest request, CancellationToken ct = default)
    {
        var item = await _repository.GetByIdAsync(id, ct);
        if (item is null) return SampleErrors.NotFound;

        item.Rename(request.Name, request.Description);
        await _unitOfWork.SaveChangesAsync(ct);
        return Result.Success();
    }
}
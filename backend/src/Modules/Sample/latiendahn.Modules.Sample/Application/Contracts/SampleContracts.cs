namespace latiendahn.Modules.Sample.Application.Contracts;

public sealed record CreateSampleRequest(string Name, string? Description);
public sealed record UpdateSampleRequest(string Name, string? Description);

public sealed record SampleResponse(Guid Id, string Name, string? Description, DateTimeOffset CreatedOn);
public sealed record CreatedResource(Guid Id);
using latiendahn.BuildingBlocks.Results;
using latiendahn.Modules.Sample.Application.Contracts;
using latiendahn.Modules.Sample.Application.Services;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace latiendahn.Modules.Sample.Api;

internal static class SampleEndpoints
{
    public static IEndpointRouteBuilder MapSampleEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/samples").WithTags("Samples");

        group.MapGet("/", async (int? page, int? pageSize, SampleQueryService queries, CancellationToken ct) =>
            Results.Ok(await queries.ListAsync(page ?? 1, pageSize ?? 20, ct)))
            .WithSummary("Lista items (paginado).");

        group.MapGet("/{id:guid}", async (Guid id, SampleQueryService queries, CancellationToken ct) =>
            (await queries.GetAsync(id, ct)).ToHttpResult())
            .WithSummary("Obtiene un item por id.");

        group.MapPost("/", async (
            CreateSampleRequest request, IValidator<CreateSampleRequest> validator,
            SampleService service, CancellationToken ct) =>
        {
            var validation = await validator.ValidateAsync(request, ct);
            if (!validation.IsValid) return Results.ValidationProblem(validation.ToDictionary());
            return (await service.CreateAsync(request, ct)).ToHttpResult(
                r => Results.Created($"/api/v1/samples/{r.Id}", r));
        }).WithSummary("Crea un item.");

        group.MapPut("/{id:guid}", async (
            Guid id, UpdateSampleRequest request, IValidator<UpdateSampleRequest> validator,
            SampleService service, CancellationToken ct) =>
        {
            var validation = await validator.ValidateAsync(request, ct);
            if (!validation.IsValid) return Results.ValidationProblem(validation.ToDictionary());
            return (await service.UpdateAsync(id, request, ct)).ToHttpResult();
        }).WithSummary("Actualiza un item.");

        return app;
    }
}
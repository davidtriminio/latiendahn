using latiendahn.BuildingBlocks.Modularity;
using latiendahn.Infrastructure.Persistence;
using latiendahn.Modules.Sample.Api;
using latiendahn.Modules.Sample.Application.Abstractions;
using latiendahn.Modules.Sample.Application.Services;
using latiendahn.Modules.Sample.Infrastructure.Persistence;
using FluentValidation;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace latiendahn.Modules.Sample;

public sealed class SampleModule : IModule
{
    public string Name => "Sample";

    public void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Postgres")
            ?? throw new InvalidOperationException("La cadena de conexion 'Postgres' no esta configurada.");

        services.AddModuleDbContext<SampleDbContext>(connectionString, "sample");
        services.AddScoped<ISampleUnitOfWork>(sp => sp.GetRequiredService<SampleDbContext>());
        services.AddScoped<ISampleRepository, SampleRepository>();
        services.AddScoped<SampleService>();
        services.AddScoped<SampleQueryService>();

        services.TryAddSingleton(TimeProvider.System);
        services.AddValidatorsFromAssemblyContaining<SampleModule>(ServiceLifetime.Scoped);
    }

    public void MapEndpoints(IEndpointRouteBuilder endpoints) => endpoints.MapSampleEndpoints();
}
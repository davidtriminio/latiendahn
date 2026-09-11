using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace latiendahn.BuildingBlocks.Modularity;

/// <summary>Lista explicita de modulos (sin escaneo de ensamblados) para que el conjunto activo sea obvio y testeable.</summary>
public sealed class ModuleRegistry
{
    private readonly List<IModule> _modules = new();
    public IReadOnlyList<IModule> Modules => _modules;

    public ModuleRegistry Add(IModule module)
    {
        _modules.Add(module);
        return this;
    }

    public void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        foreach (var module in _modules) module.RegisterServices(services, configuration);
    }

    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        foreach (var module in _modules) module.MapEndpoints(endpoints);
    }
}
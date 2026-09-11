using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace latiendahn.BuildingBlocks.Modularity;

/// <summary>
/// Contrato que implementa cada modulo para que el composition root lo descubra y lo cablee sin
/// conocer sus internals. Es la costura que mantiene modular al monolito: el host solo conoce IModule.
/// </summary>
public interface IModule
{
    string Name { get; }
    void RegisterServices(IServiceCollection services, IConfiguration configuration);
    void MapEndpoints(IEndpointRouteBuilder endpoints);
}
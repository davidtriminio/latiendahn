using latiendahn.BuildingBlocks.Modularity;
using latiendahn.Modules.Sample;

var builder = WebApplication.CreateBuilder(args);

// Registro explicito de modulos que componen este monolito.
var modules = new ModuleRegistry()
    .Add(new SampleModule());

builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();

modules.RegisterServices(builder.Services, builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/", () => Results.Ok(new
{
    service = "latiendahn API",
    status = "ok",
    modules = modules.Modules.Select(m => m.Name).ToArray()
}));

modules.MapEndpoints(app);

app.Run();

// Expuesto para que los tests de integracion (WebApplicationFactory) referencien el entry point.
public partial class Program;
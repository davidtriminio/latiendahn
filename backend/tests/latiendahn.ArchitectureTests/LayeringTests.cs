using NetArchTest.Rules;
using latiendahn.Modules.Sample.Domain;
using Xunit;

namespace latiendahn.ArchitectureTests;

/// <summary>Reglas de frontera del monolito modular. Replica una por regla al anadir modulos.</summary>
public sealed class LayeringTests
{
    private const string DomainNamespace = "latiendahn.Modules.Sample.Domain";

    [Fact]
    public void Domain_should_not_depend_on_EntityFrameworkCore()
    {
        var result = Types.InAssembly(typeof(SampleItem).Assembly)
            .That().ResideInNamespace(DomainNamespace)
            .ShouldNot().HaveDependencyOn("Microsoft.EntityFrameworkCore")
            .GetResult();

        Assert.True(result.IsSuccessful, string.Join(", ", result.FailingTypeNames ?? System.Array.Empty<string>()));
    }
}
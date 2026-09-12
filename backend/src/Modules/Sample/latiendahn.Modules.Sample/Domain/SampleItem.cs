using latiendahn.BuildingBlocks.Domain;

namespace latiendahn.Modules.Sample.Domain;

/// <summary>Aggregate root de ejemplo. Reemplazalo por tu entidad real al clonar el modulo.</summary>
public sealed class SampleItem : AggregateRoot
{
    public string Name { get; private set; } = default!;
    public string? Description { get; private set; }
    public DateTimeOffset CreatedOn { get; private set; }

    private SampleItem() { }

    public static SampleItem Create(string name, string? description, DateTimeOffset now) => new()
    {
        Id = Guid.NewGuid(),
        Name = name.Trim(),
        Description = description,
        CreatedOn = now
    };

    public void Rename(string name, string? description)
    {
        Name = name.Trim();
        Description = description;
    }
}
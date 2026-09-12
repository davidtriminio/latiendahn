namespace latiendahn.BuildingBlocks.Domain;

public interface IDomainEvent
{
    DateTimeOffset OccurredOn { get; }
}
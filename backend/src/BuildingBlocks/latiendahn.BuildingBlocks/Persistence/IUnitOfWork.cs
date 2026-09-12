namespace latiendahn.BuildingBlocks.Persistence;

/// <summary>Un solo punto para confirmar los cambios de un modulo dentro de una transaccion logica.</summary>
public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
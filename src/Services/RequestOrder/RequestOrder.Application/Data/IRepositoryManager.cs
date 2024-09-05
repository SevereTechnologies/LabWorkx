using System.Data;

namespace RequestOrder.Application.Data;

public interface IRepositoryManager
{
    IOrderRepository Order { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken = default);

    Task<IDbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

    IDbTransaction BeginTransaction();
}

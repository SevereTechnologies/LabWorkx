using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace RequestOrder.Infrastructure.Repository;

internal sealed class RepositoryManager(ApplicationDbContext dbContext, IOrderRepository orderRepository) : IRepositoryManager
{
    public IOrderRepository Order => orderRepository;

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await dbContext.SaveChangesAsync(cancellationToken);

    public async Task<IDbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        return transaction.GetDbTransaction();
    }

    public IDbTransaction BeginTransaction()
    {
        var transaction = dbContext.Database.BeginTransaction();
        return transaction.GetDbTransaction();
    }
}

namespace RequestOrder.Application.Data;

public interface IRepositoryManager
{
    IOrderRepository Order { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}

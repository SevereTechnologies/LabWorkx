namespace WorkOrder.API.Repository;

public class WorkOrderRepository(IDocumentSession session) : IWorkOrderRepository
{
    public async Task<List<WorkItem>> GetWorkOrdersAsync(Guid technicianId, CancellationToken cancellationToken = default)
    {
        var items = await session.LoadAsync<List<WorkItem>>(technicianId, cancellationToken);

        return items;
    }

    public async Task<WorkItem?> GetWorkOrderAsync(Guid requestId, CancellationToken cancellationToken = default)
    {
        var item = await session.LoadAsync<WorkItem>(requestId, cancellationToken);

        return item;
    }

    public async Task<WorkItem> StoreWorkOrderAsync(WorkItem item, CancellationToken cancellationToken = default)
    {
        session.Store(item);

        await session.SaveChangesAsync(cancellationToken);

        return item;
    }

    public async Task<bool> DeleteWorkOrderAsync(Guid requestId, CancellationToken cancellationToken = default)
    {
        session.Delete<WorkItem>(requestId);

        await session.SaveChangesAsync(cancellationToken);

        return true;
    }
}

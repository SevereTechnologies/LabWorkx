namespace WorkOrder.API.Repository;

public interface IWorkOrderRepository
{
    Task<List<WorkItem>> GetWorkOrdersAsync(Guid technicianId, CancellationToken cancellationToken = default);
    Task<WorkItem?> GetWorkOrderAsync(Guid requestId, CancellationToken cancellationToken = default);
    Task<WorkItem> StoreWorkOrderAsync(WorkItem item, CancellationToken cancellationToken = default);
    Task<bool> DeleteWorkOrderAsync(Guid requestId, CancellationToken cancellationToken = default);
}
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace WorkOrder.API.Repository;

public class RedisCacheWorkOrderRepository(IWorkOrderRepository repository, IDistributedCache cache) : IWorkOrderRepository
{
    public async Task<List<WorkItem>> GetWorkOrdersAsync(Guid technicianId, CancellationToken cancellationToken = default)
    {
        var cachedWorkOrder = await cache.GetStringAsync(technicianId.ToString(), cancellationToken);
        if (!string.IsNullOrEmpty(cachedWorkOrder))
        {
            return JsonSerializer.Deserialize<List<WorkItem>>(cachedWorkOrder)!;
        }

        var WorkItems = await repository.GetWorkOrdersAsync(technicianId, cancellationToken);
        await cache.SetStringAsync(technicianId.ToString(), JsonSerializer.Serialize(WorkItems), cancellationToken);
        return WorkItems;
    }

    public async Task<WorkItem?> GetWorkOrderAsync(Guid requestId, CancellationToken cancellationToken = default)
    {
        var cachedWorkOrder = await cache.GetStringAsync(requestId.ToString(), cancellationToken);
        if (!string.IsNullOrEmpty(cachedWorkOrder))
        {
            return JsonSerializer.Deserialize<WorkItem>(cachedWorkOrder)!;
        }
            
        var workItem = await repository.GetWorkOrderAsync(requestId, cancellationToken);
        await cache.SetStringAsync(requestId.ToString(), JsonSerializer.Serialize(workItem), cancellationToken);
        return workItem;
    }

    public async Task<WorkItem> StoreWorkOrderAsync(WorkItem workItem, CancellationToken cancellationToken = default)
    {
        await repository.StoreWorkOrderAsync(workItem, cancellationToken);

        await cache.SetStringAsync(workItem.RequestId.ToString(), JsonSerializer.Serialize(workItem), cancellationToken);

        return workItem;
    }

    public async Task<bool> DeleteWorkOrderAsync(Guid requestId, CancellationToken cancellationToken = default)
    {
        await repository.DeleteWorkOrderAsync(requestId, cancellationToken);

        await cache.RemoveAsync(requestId.ToString(), cancellationToken);

        return true;
    }
}

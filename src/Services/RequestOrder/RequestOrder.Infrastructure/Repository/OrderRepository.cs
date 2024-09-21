namespace RequestOrder.Infrastructure.Repository;

internal sealed class OrderRepository(ApplicationDbContext dbContext) : IOrderRepository
{
    public async Task<IEnumerable<Order>?> GetOrdersByProviderAsync(ProviderId providerId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Orders
            //.Include(x => x.OrderItems)
            .AsNoTracking()
            .Where(m => m.ProviderId == providerId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Order>?> GetOrdersByPatientAsync(PatientId patientId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Orders
            //.Include(x => x.OrderItems)
            .AsNoTracking()
            .Where(m => m.PatientId == patientId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Order>?> GetOrdersByTechnicianAsync(TechnicianId technicianId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Orders
            //.Include(x => x.OrderItems)
            .AsNoTracking()
            .Where(m => m.TechnicianId == technicianId)
            .ToListAsync(cancellationToken);
    }

    public async Task<Order?> GetByNumberAsync(OrderNumber orderNumber, CancellationToken cancellationToken = default)
    {
        return await dbContext.Orders
            //.Include(x => x.OrderItems)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.OrderNumber == orderNumber, cancellationToken);
    }

    public async Task<Order?> GetByIdAsync(OrderId orderId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Orders
            //.Include(x => x.OrderItems)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == orderId, cancellationToken);
    }

    public async Task<Order?> FindAsync(OrderId orderId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Orders
            .FindAsync([orderId], cancellationToken: cancellationToken);
    }

    public void Add(Order order)
    {
        dbContext.Set<Order>().Add(order);
    }
    public void Update(Order order)
    {
        dbContext.Set<Order>().Update(order);
    }
    public void Delete(Order order)
    {
        dbContext.Set<Order>().Remove(order);
    }
}

namespace RequestOrder.Application.Data;

public interface IOrderRepository
{
    Task<IEnumerable<Order>?> GetOrdersByProviderAsync(ProviderId providerId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Order>?> GetOrdersByPatientAsync(PatientId patientId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Order>?> GetOrdersByTechnicianAsync(TechnicianId technicianId, CancellationToken cancellationToken = default);
    Task<Order?> GetByNumberAsync(OrderNumber orderNumber, CancellationToken cancellationToken = default);
    Task<Order?> GetByIdAsync(OrderId orderId, CancellationToken cancellationToken = default);
    Task<Order?> FindAsync(OrderId orderId, CancellationToken cancellationToken = default);

    void Add(Order order);
    void Update(Order order);
    void Delete(Order order);
}

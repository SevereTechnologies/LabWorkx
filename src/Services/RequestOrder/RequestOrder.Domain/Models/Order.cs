using RequestOrder.Domain.Abstractions;
using RequestOrder.Domain.Enums;
using RequestOrder.Domain.ValueObjects;

namespace RequestOrder.Domain.Models;

public class Order : Aggregate<OrderId>
{
    private readonly List<OrderItem> _orderItems = new();

    public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();

    public OrderNumber OrderNumber { get; private set; } = default!;
    public TechnicianId TechnicianId { get; private set; } = default!;
    public ProviderId ProviderId { get; private set; } = default!;
    public PatientId PatientId { get; private set; } = default!;
    public LabId LabId { get; private set; } = default!;
    public ShipperId ShipperId { get; private set; } = default!;
    public Payment Payment { get; private set; } = default!;
    public OrderStatus Status { get; private set; } = OrderStatus.Received;
    public decimal TotalDue
    {
        get => OrderItems.Sum(x => x.Price * x.Quantity);
        private set { }
    }

}
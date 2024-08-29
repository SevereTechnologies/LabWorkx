﻿namespace RequestOrder.Domain.Models;

/// <summary>
/// Order is the Aggregate root entity (parent).
/// Order aka the Aggregate Root is reponsible for managing, creating its children (OrderItem)
/// that includes: Create Order and Add OrderItem(s) to the Order
/// </summary>
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
    public decimal ChargeAmount
    {
        get => OrderItems.Sum(x => x.Charge * x.Quantity);
        private set { }
    }

    /// <summary>
    /// Create New Order
    /// </summary>
    /// <param name="id"></param>
    /// <param name="orderNumber"></param>
    /// <param name="technicianId"></param>
    /// <param name="providerId"></param>
    /// <param name="patientId"></param>
    /// <param name="labId"></param>
    /// <param name="shipperId"></param>
    /// <param name="payment"></param>
    /// <returns></returns>
    public static Order Create(OrderId id, OrderNumber orderNumber, TechnicianId technicianId,
        ProviderId providerId, PatientId patientId, LabId labId, ShipperId shipperId, Payment payment)
    {
        var order = new Order()
        {
            Id = id,
            OrderNumber = orderNumber,
            TechnicianId = technicianId,
            ProviderId = providerId,
            PatientId = patientId,
            LabId = labId,
            ShipperId = shipperId,
            Payment = payment,
            Status = OrderStatus.Received
        };

        order.AddDomainEvent(new OrderCreatedDomainEvent(order));

        return order;
    }

    /// <summary>
    /// Update Existing Order
    /// </summary>
    /// <param name="orderNumber"></param>
    /// <param name="technicianId"></param>
    /// <param name="labId"></param>
    /// <param name="shipperId"></param>
    /// <param name="payment"></param>
    /// <param name="status"></param>
    public void Update(OrderNumber orderNumber, TechnicianId technicianId, LabId labId, ShipperId shipperId, Payment payment, OrderStatus status)
    {
        OrderNumber = orderNumber;
        TechnicianId = technicianId;
        LabId = labId;
        ShipperId = shipperId;
        Payment = payment;
        Status = status;

        AddDomainEvent(new OrderUpdatedDomainEvent(this));
    }

    /// <summary>
    /// Add a LineItem to an Order
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="procedureId"></param>
    /// <param name="quantity"></param>
    /// <param name="charge"></param>
    public void Add(OrderId orderId, ProcedureId procedureId, int quantity, decimal charge)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(charge);

        var orderItem = new OrderItem(orderId, procedureId,  quantity, charge);

        _orderItems.Add(orderItem);
    }

    public void Remove(ProcedureId procedureId)
    {
        var orderItem = _orderItems.FirstOrDefault(x => x.ProcedureId == procedureId);
        if (orderItem is not null)
        {
            _orderItems.Remove(orderItem);
        }
    }
}
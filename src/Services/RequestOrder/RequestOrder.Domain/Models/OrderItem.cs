using RequestOrder.Domain.Abstractions;
using RequestOrder.Domain.ValueObjects;

namespace RequestOrder.Domain.Models;

/// <summary>
/// OrderItem is the child of the Aggregate root entity (it's parent) which is Order.
/// Order aka the Aggregate Root is reponsible for managing, creating its children
/// that includes: Create Order and Add OrderItem(s) to the Order
/// </summary>
public class OrderItem : Aggregate<OrderItemId>
{
    public OrderItem(OrderId orderId, string procedureCode, string diagnosis, int quanity, decimal price, bool completed, string comment)
    {
        Id = OrderItemId.Of(Guid.NewGuid());
        OrderId = orderId;
        ProcedureCode = procedureCode;
        Quantity = quanity;
        Price = price;
        Completed = completed;
        Comment = comment;
    }

    public OrderId OrderId { get; private set; } = default!;
    public string ProcedureCode { get; private set; } = default!;
    public string Diagnosis { get; private set; } = default!;
    public int Quantity { get; private set; } = default!; // exp: quantity of blood valves taken
    public decimal Price { get; private set; } = default!; // exp: price per unit
    public bool Completed { get; private set; } = default!;
    public string Comment { get; private set; } = default!;
}

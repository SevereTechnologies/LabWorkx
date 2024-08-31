namespace RequestOrder.Domain.Models;

/// <summary>
/// OrderItem is the child of the Aggregate root entity (it's parent) which is Order.
/// Order aka the Aggregate Root is reponsible for managing, creating its children
/// that includes: Create Order and Add OrderItem(s) to the Order
/// </summary>
public class OrderItem : Aggregate<OrderItemId>
{
    internal OrderItem(OrderId orderId, ProcedureId procedureId, int quantity, decimal cost)
    {
        Id = OrderItemId.Of(Guid.NewGuid());
        OrderId = orderId;
        ProcedureId = procedureId;
        Quantity = quantity;
        Cost = cost;
    }

    public OrderId OrderId { get; private set; } = default!;
    public ProcedureId ProcedureId { get; private set; } = default!;
    public int Quantity { get; private set; } = default!; // exp: quantity of blood valves taken
    public decimal Cost { get; private set; } = default!; // exp: price per unit
}

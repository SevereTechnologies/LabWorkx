namespace RequestOrder.Domain.Enums;

public enum OrderStatus
{
    Received = 1,
    Collected = 2,
    Shipped = 3,
    Delivered = 4,
    Completed = 5,
    OnHold = 6,
    Cancelled = 7
}

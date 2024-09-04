namespace RequestOrder.Domain.Events;

public class OrderUpdatedEvent(Order order) : IDomainEvent;

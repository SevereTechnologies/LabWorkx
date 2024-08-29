namespace RequestOrder.Domain.Events;

public class OrderUpdatedDomainEvent(Order order) : IDomainEvent;

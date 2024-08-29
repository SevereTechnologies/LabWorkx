namespace RequestOrder.Domain.Events;

public record OrderCreatedDomainEvent(Order order) : IDomainEvent;
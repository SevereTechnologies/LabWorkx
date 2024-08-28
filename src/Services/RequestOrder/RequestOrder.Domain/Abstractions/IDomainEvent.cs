using MediatR;

namespace RequestOrder.Domain.Abstractions;

public interface IDomainEvent : INotification
{
    Guid EentId => Guid.NewGuid();
    public DateTime OccuredOn => DateTime.UtcNow;
    public string EventType => GetType().AssemblyQualifiedName;
}
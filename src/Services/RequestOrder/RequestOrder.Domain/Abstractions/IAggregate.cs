namespace RequestOrder.Domain.Abstractions;

/// <summary>
/// base level interface
/// </summary>
public interface IAggregate : IEntity
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    IDomainEvent[] ClearDomainEvents();
}

/// <summary>
/// Interface that implement above interface
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IAggregate<T> : IAggregate, IEntity<T>
{
}


/// <summary>
/// The base class aggregate that inheritates from and implments above
/// </summary>
/// <typeparam name="TId"/>
public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public IDomainEvent[] ClearDomainEvents()
    {
        IDomainEvent[] domainEvents = _domainEvents.ToArray();

        _domainEvents.Clear();

        return domainEvents;
    }
}
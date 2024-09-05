using MediatR;

namespace RequestOrder.Infrastructure.Interceptors;

public class DispatchDomainEventsInterceptor(IMediator mediator) : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        DispatchDomainEvents(eventData.Context).GetAwaiter().GetResult();

        return base.SavingChanges(eventData, result);
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await DispatchDomainEvents(eventData.Context);

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public async Task DispatchDomainEvents(DbContext? context)
    {
        // leave if there's no dbcontext
        if (context == null) return;

        // retrieve the aggregates from the dbContext entities that implement the IAggregate interface
        var aggregates = context.ChangeTracker
            .Entries<IAggregate>()
            .Where(a => a.Entity.DomainEvents.Any())
            .Select(a => a.Entity);

        // get all domainevents from the all aggregates and convert them a list
        var domainEvents = aggregates
            .SelectMany(a => a.DomainEvents)
            .ToList();

        // now we can clear the domainevents from the aggregates since we pull them out above
        aggregates.ToList().ForEach(a => a.ClearDomainEvents());

        // now for each domainEvents, publish them to the consumer side using MediatR.
        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);
        }
    }
}

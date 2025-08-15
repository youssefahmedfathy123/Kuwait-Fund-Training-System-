using MediatR;

public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IMediator _mediator;

    public DomainEventDispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task DispatchDomainEventsAsync(IEnumerable<AggragateRoot<Guid>> entities, CancellationToken cancellationToken = default)
    {
        var domainEvents = entities
            .SelectMany(e => e.DomainEvents)
            .ToList();

        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent, cancellationToken);
        }

        foreach (var entity in entities)
        {
            entity.ClearDomainEvents();
        }
    }
}




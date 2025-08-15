public interface IDomainEventDispatcher
{
    Task DispatchDomainEventsAsync(IEnumerable<AggragateRoot<Guid>> entities, CancellationToken cancellationToken = default);
}




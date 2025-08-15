using Domain.Primitives;

public abstract class AggragateRoot<T> : Entity<T>
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    protected AggragateRoot()
    {
        
    }
    protected AggragateRoot(T id)
        :base(id)
    {
        
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}


using DNA.Labs.Labs7._02.Events;

namespace DNA.Labs.Labs7._02.SharedKernel;

public abstract class AggregateRoot
{
    private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void ClearDomainEvents() => _domainEvents.Clear();
        
    protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}
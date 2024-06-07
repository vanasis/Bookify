namespace Bookify.Domain.Abstractions;

public abstract class Entity
{
    public Guid Id { get; init; }

    protected Entity(Guid id)
    {
        Id = id;
    }

    #region Domain Event
    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    // Raise a domain event when something happen inside domain level
    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    #endregion
}
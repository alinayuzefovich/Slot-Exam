using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class AggregateRoot: Entity
{
    private readonly List<IDomainEvent> events;

    public IReadOnlyCollection<IDomainEvent> Events => events;

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        events.Add(domainEvent);
    }

    public void ClearDomainEvents() => events.Clear();
}

using core.Patterns.EventSourcing;
using System;
using System.Collections.Generic;

namespace core.Types
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        private List<Event> _domainEvents;
        public IReadOnlyCollection<Event> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddNewId()
        {
            Id = Guid.NewGuid();
        }

        public void AddDomainEvent(Event domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<Event>();
            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(Event domainEvent)
        {
            _domainEvents?.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}
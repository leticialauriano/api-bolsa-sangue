using MediatR;
using System;

namespace core.Patterns.EventSourcing
{
    public abstract class Event : INotification
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            MessageType = GetType().Name;
            Timestamp = DateTime.Now;
        }
    }
}
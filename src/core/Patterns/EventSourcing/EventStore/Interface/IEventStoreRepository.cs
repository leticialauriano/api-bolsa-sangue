
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace core.Patterns.EventSourcing.EventStore
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        Task<IList<StoredEvent>> All(Guid aggregateId);
    }
}
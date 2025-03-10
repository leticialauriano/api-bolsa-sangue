using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace core.Patterns.EventSourcing.EventStore.Repository
{
    public class EventStoreRepository : IEventStoreRepository
    {
        protected readonly IEventStoreContext _context;
        protected readonly IMongoCollection<StoredEvent> DbSet;
        public EventStoreRepository(IEventStoreContext context)
        {
            DbSet = context.GetCollection<StoredEvent>(typeof(StoredEvent).Name);
            _context = context;
        }

        public virtual async Task<IList<StoredEvent>> All(Guid aggregateId)
        {
            var all = await DbSet.FindAsync(Builders<StoredEvent>.Filter.Eq("AggregateId", aggregateId));
            return all.ToList();
        }

        public void Store(StoredEvent theEvent)
        {
            _context.AddCommand(async () => await DbSet.InsertOneAsync(theEvent));
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
using core.Patterns.EventSourcing.EventStore;
using Newtonsoft.Json;

namespace core.Patterns.EventSourcing
{
    public class MongoEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly string _user = "Anonymous";

        public MongoEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);
            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                _user);

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
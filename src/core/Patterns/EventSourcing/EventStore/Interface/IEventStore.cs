namespace core.Patterns.EventSourcing.EventStore
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
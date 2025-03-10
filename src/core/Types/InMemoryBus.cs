using core.Patterns.EventSourcing;
using core.Patterns.EventSourcing.EventStore;
using core.Patterns.MediatR;
using FluentValidation.Results;
using MediatR;
using System.Threading.Tasks;

namespace core.Types
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;
        private readonly bool _eventStoreEnabled = false;

        public InMemoryBus(
            IEventStore eventStore,
            IMediator mediator)
            //IConfiguration config)
        {
            //var eventStoreEnable = config.GetSection("EventStoreSettings.Enabled").Value;
            //if (!string.IsNullOrWhiteSpace(eventStoreEnable))
            //    _eventStoreEnabled = Convert.ToBoolean(eventStoreEnable);

            _eventStore = eventStore;
            _mediator = mediator;
        }

        public async Task PublishEvent<T>(T @event) where T : Event
        {
            if (_eventStoreEnabled && !@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            await _mediator.Publish(@event);
        }

        public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
    }
}
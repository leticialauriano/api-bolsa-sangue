using core.Patterns.EventSourcing;
using core.Types;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace core.Patterns.MediatR
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
using M4.DataContracts.CQS.Events;
using System.Threading.Tasks;

namespace M4.BusinessLogic.CQRS.Events
{
    public interface IHandleEvent
    {
    }

    public interface IHandleEvent<TEvent> : IHandleEvent where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event);
    }
}
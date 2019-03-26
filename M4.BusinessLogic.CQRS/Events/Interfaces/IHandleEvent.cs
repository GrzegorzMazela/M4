using M4.DataContracts.CQRS.Events.Interfaces;

namespace M4.BusinessLogic.CQRS.Events.Interfaces
{
    public interface IHandleEvent
    {
    }

    public interface IHandleEvent<TEvent> : IHandleEvent where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }
}
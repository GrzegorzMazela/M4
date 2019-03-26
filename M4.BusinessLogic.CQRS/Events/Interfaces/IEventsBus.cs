using M4.DataContracts.CQRS.Events.Interfaces;

namespace M4.BusinessLogic.CQRS.Events.Interfaces
{
    public interface IEventsBus
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
using M4.DataContracts.CQS.Events;
using System.Threading.Tasks;

namespace M4.BusinessLogic.CQRS.Events
{
    public interface IEventsDispatcher
    {
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
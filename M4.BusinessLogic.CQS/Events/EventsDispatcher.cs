using M4.DataContracts.CQS.Events;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace M4.BusinessLogic.CQRS.Events
{
    public class EventsDispatcher : IEventsDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public EventsDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var handlerType = typeof(IHandleEvent<>)
                .MakeGenericType(@event.GetType());

            dynamic handlers = serviceProvider.GetServices(handlerType);

            foreach (var handler in handlers)
            {
                await handler.Handle(@event);
            }
        }
    }
}
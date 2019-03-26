using M4.BusinessLogic.CQRS.Events.Interfaces;
using M4.DataContracts.CQRS.Events.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M4.BusinessLogic.CQRS.Events
{
    public class EventsBus : IEventsBus
    {
        private readonly Func<Type, IEnumerable<IHandleEvent>> _handlersFactory;

        public EventsBus(Func<Type, IEnumerable<IHandleEvent>> handlersFactory)
        {
            _handlersFactory = handlersFactory;
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var handlers = _handlersFactory(typeof(TEvent)).Cast<IHandleEvent<TEvent>>();

            foreach (var handler in handlers)
            {
                handler.Handle(@event);
            }
        }
    }
}
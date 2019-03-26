using M4.DataContracts.CQRS;
using M4.DataContracts.CQRS.Events.Interfaces;
using System;

namespace M4.BusinessLogic.CQRS.Events
{
    public abstract class BaseEvent : BaseEvent<Guid>
    {
    }

    public abstract class BaseEvent<TRequestId> : IBaseRequest<TRequestId>, IEvent
    {
        public TRequestId RequestId { get; set; }
    }
}
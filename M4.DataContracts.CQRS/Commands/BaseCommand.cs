using M4.DataContracts.CQRS.Commands.Interfaces;
using System;

namespace M4.DataContracts.CQRS.Commands
{
    public abstract class BaseCommand : BaseCommand<Guid>
    {
    }

    public abstract class BaseCommand<TRequestId> : IBaseRequest<TRequestId>, ICommand
    {
        public TRequestId RequestId { get; set; }
    }
}
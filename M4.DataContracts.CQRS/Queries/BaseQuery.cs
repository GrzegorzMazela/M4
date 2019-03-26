using M4.DataContracts.CQRS.Queries.Interfaces;
using System;

namespace M4.DataContracts.CQRS.Queries
{
    public abstract class BaseQuery : BaseQuery<Guid>
    {
    }

    public abstract class BaseQuery<TRequestId> : IBaseRequest<TRequestId>, IQuery
    {
        public TRequestId RequestId { get; set; }
    }
}
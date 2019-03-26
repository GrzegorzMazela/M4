using M4.DataContracts.CQRS.Queries.Interfaces;

namespace M4.BusinessLogic.CQRS.Queries.Interfaces
{
    public interface IHandleQuery
    {
    }

    public interface IHandleQuery<TQuery, TQueryResponse> : IHandleQuery where TQuery : IQuery where TQueryResponse : IQueryResponse
    {
        TQueryResponse Handle(TQuery query);
    }
}
using M4.DataContracts.CQRS.Queries.Interfaces;

namespace M4.BusinessLogic.CQRS.Queries.Interfaces
{
    public interface IQueryBus
    {
        TQueryResponse Query<TQuery, TQueryResponse>(TQuery query) where TQuery : IQuery where TQueryResponse : IQueryResponse;
    }
}
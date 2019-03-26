using M4.BusinessLogic.CQRS.Queries.Interfaces;
using M4.DataContracts.CQRS.Queries.Interfaces;
using System;

namespace M4.BusinessLogic.CQRS.Queries
{
    public class QueryBus : IQueryBus
    {
        private readonly Func<Type, Type, IHandleQuery> _handlersFactory;

        public QueryBus(Func<Type, Type, IHandleQuery> handlersFactory)
        {
            _handlersFactory = handlersFactory;
        }

        public TQueryResponse Query<TQuery, TQueryResponse>(TQuery query)
            where TQuery : IQuery
            where TQueryResponse : IQueryResponse
        {
            var handler = (IHandleQuery<TQuery, TQueryResponse>)_handlersFactory(typeof(TQuery), typeof(TQueryResponse));
            return handler.Handle(query);
        }
    }
}
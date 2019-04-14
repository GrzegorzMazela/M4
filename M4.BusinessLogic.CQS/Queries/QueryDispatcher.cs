using M4.DataContracts.CQS.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace M4.BusinessLogic.CQS.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>)
                    .MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = serviceProvider.GetService(handlerType);
            return await handler.HandleAsync((dynamic)query);
        }
    }
}
using M4.DataContracts.CQS.Queries;
using System.Threading.Tasks;

namespace M4.BusinessLogic.CQS.Queries
{
    public interface IQueryHandler
    {
    }

    public interface IQueryHandler<TQuery, TResult> : IQueryHandler where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
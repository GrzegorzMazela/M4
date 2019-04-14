using M4.DataContracts.CQS.Queries;
using System.Threading.Tasks;

namespace M4.BusinessLogic.CQS.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
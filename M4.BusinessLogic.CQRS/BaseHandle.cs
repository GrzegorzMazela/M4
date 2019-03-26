using M4.DataContracts.CQRS;
using System;
using System.Threading.Tasks;

namespace M4.BusinessLogic.CQRS
{
    public abstract class BaseHandle
    {
        protected virtual void InvokeLogic<TSource, TResponse, TRequest>(string method, TSource source, TResponse response, TRequest request, Action action)
         where TResponse : IBaseResponse<Guid>
         where TRequest : IBaseRequest<Guid>
        {
            response.ResponseId = Guid.NewGuid();

            try
            {
                action();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.SetFailResponse(ex);
            }
        }

        protected virtual async Task InvokeLogicAsync<TSource, TResponse, TRequest>(string method, TSource source, TResponse response, TRequest request, Func<Task> action)
        where TResponse : IBaseResponse<Guid>
        where TRequest : IBaseRequest<Guid>
        {
            response.ResponseId = Guid.NewGuid();

            try
            {
                await action();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.SetFailResponse(ex);
            }
        }
    }
}
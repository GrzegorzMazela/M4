using M4.DataContracts.CQRS.Queries.Interfaces;
using System;

namespace M4.DataContracts.CQRS.Queries
{
    public abstract class BaseQueryResponse : BaseQueryResponse<Guid>
    {
    }

    public abstract class BaseQueryResponse<TResponseId> : IBaseResponse<TResponseId>, IQueryResponse
    {
        public TResponseId ResponseId { get; set; }
        public bool Success { get; set; }
        public Exception Exception { get; set; }

        public virtual void SetSuccessReponse() => SetResponse();

        public virtual void SetFailResponse<TException>(TException ex)
            where TException : Exception
             => SetResponse(false, ex);

        public virtual void SetFailResponse(string exMessage)
            => SetResponse(false, new Exception(exMessage));

        protected virtual void SetResponse(bool success = true, Exception ex = null)
        {
            Success = success;
            Exception = ex;
        }
    }
}
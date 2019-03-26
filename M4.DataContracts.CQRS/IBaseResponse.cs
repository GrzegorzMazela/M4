using System;

namespace M4.DataContracts.CQRS
{
    public interface IBaseResponse<TResponseId>
    {
        TResponseId ResponseId { get; set; }
        bool Success { get; set; }
        Exception Exception { get; set; }

        void SetSuccessReponse();

        void SetFailResponse(string exMessage);

        void SetFailResponse<TException>(TException ex) where TException : Exception;
    }
}
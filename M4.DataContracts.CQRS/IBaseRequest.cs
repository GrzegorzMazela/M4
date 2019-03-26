namespace M4.DataContracts.CQRS
{
    public interface IBaseRequest<TRequestId>
    {
        TRequestId RequestId { get; set; }
    }
}
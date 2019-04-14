namespace M4.DataContracts.CQS.Commands
{
    public interface ICommand
    {
    }

    public interface ICommand<out TResult> : ICommand
    {
    }
}

using M4.DataContracts.CQS.Commands;
using System.Threading.Tasks;

namespace M4.BusinessLogic.CQS.Commands
{
    public interface ICommandDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;

        Task<TResult> SendAsync<TResult>(ICommand<TResult> command);
    }
}
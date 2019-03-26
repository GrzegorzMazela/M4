using M4.DataContracts.CQRS.Commands.Interfaces;

namespace M4.BusinessLogic.CQRS.Commands.Interfaces
{
    public interface IHandleCommand
    {
    }   

    public interface IHandleCommand<TCommand> : IHandleCommand where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
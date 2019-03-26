using M4.DataContracts.CQRS.Commands.Interfaces;

namespace M4.BusinessLogic.CQRS.Commands.Interfaces
{
    public interface ICommandsBus
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
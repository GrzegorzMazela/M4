using M4.BusinessLogic.CQRS.Commands.Interfaces;
using M4.DataContracts.CQRS.Commands.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace M4.BusinessLogic.CQRS.Commands
{
    public class CommandsBus : ICommandsBus
    {
        private readonly Func<Type, IHandleCommand> _handlersFactory;

        public CommandsBus(Func<Type, IHandleCommand> handlersFactory)
        {
            _handlersFactory = handlersFactory;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = (IHandleCommand<TCommand>)_handlersFactory(typeof(TCommand));
            handler.Handle(command);
        }
    }
}

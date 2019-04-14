using M4.DataContracts.CQS.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace M4.BusinessLogic.CQS.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = serviceProvider.GetService<ICommandHandler<TCommand>>();
            await handler.HandleAsync(command);
        }

        public async Task<TResult> SendAsync<TResult>(ICommand<TResult> command)
        {
            var handlerType = typeof(ICommandHandler<,>)
                    .MakeGenericType(command.GetType(), typeof(TResult));

            dynamic handler = serviceProvider.GetService(handlerType);
            return await handler.HandleAsync((dynamic)command);
        }
    }
}
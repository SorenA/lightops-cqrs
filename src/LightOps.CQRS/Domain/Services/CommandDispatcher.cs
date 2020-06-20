using System;
using System.Threading.Tasks;
using LightOps.CQRS.Api.Commands;
using LightOps.CQRS.Api.Services;
using LightOps.CQRS.Domain.Exceptions;

namespace LightOps.CQRS.Domain.Services
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchAsync<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            // Resolve command handler
            var handler = _serviceProvider.GetService(typeof(ICommandHandler<TCommand>)) as ICommandHandler<TCommand>;
            if (handler == null)
            {
                throw new CommandHandlerNotFoundException(typeof(TCommand));
            }

            await handler.HandleAsync(command);
        }
    }
}
using System.Threading.Tasks;
using LightOps.CQRS.Api.Commands;
using LightOps.CQRS.Api.Services;

namespace LightOps.CQRS.Test.Mock
{
    public class NullCommandDispatcher : ICommandDispatcher
    {
        public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            await Task.Yield();
        }
    }
}
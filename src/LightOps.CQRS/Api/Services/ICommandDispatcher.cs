using System.Threading.Tasks;
using LightOps.CQRS.Api.Commands;

namespace LightOps.CQRS.Api.Services
{
    /// <summary>
    /// Command dispatcher for dispatching and handling commands
    /// </summary>
    public interface ICommandDispatcher
    {
        /// <summary>
        /// Dispatches command of type <typeparamref name="TCommand"/> async
        /// </summary>
        /// <typeparam name="TCommand">The command type to handle</typeparam>
        /// <param name="command">The command to handle</param>
        /// <returns>Awaitable task for command handling completion</returns>
        Task DispatchAsync<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}
using System.Threading.Tasks;

namespace LightOps.CQRS.Api.Commands
{
    /// <summary>
    /// Command handler for handling commands of type <typeparamref name="TCommand"/>
    /// </summary>
    /// <typeparam name="TCommand">The command type to handle</typeparam>
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        /// <summary>
        /// Handles commands of type <typeparamref name="TCommand"/> async
        /// </summary>
        /// <param name="command">The command to handle</param>
        /// <returns>Awaitable task for command handling completion</returns>
        Task HandleAsync(TCommand command);
    }
}
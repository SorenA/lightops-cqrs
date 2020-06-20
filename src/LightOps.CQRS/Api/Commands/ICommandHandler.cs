using System.Threading.Tasks;

namespace LightOps.CQRS.Api.Commands
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
using System.Threading.Tasks;
using LightOps.CQRS.Api.Commands;

namespace LightOps.CQRS.Api.Services
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}
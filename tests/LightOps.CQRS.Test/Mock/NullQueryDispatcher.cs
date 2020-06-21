using System.Threading.Tasks;
using LightOps.CQRS.Api.Commands;
using LightOps.CQRS.Api.Queries;
using LightOps.CQRS.Api.Services;

namespace LightOps.CQRS.Test.Mock
{
    public class NullQueryDispatcher : IQueryDispatcher
    {
        public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            await Task.Yield();
        }

        public async Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            return await Task.FromResult(default(TResult));
        }
    }
}
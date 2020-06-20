using System.Threading.Tasks;
using LightOps.CQRS.Api.Queries;

namespace LightOps.CQRS.Api.Services
{
    public interface IQueryDispatcher
    {
        Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query)
            where TQuery : IQuery;
    }
}
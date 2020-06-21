using System.Threading.Tasks;
using LightOps.CQRS.Api.Queries;

namespace LightOps.CQRS.Api.Services
{
    /// <summary>
    /// Query dispatcher for dispatching and handling queries
    /// </summary>
    public interface IQueryDispatcher
    {
        /// <summary>
        /// Dispatches query of type <typeparamref name="TQuery"/> async with an expected result of type <typeparamref name="TResult"/> 
        /// </summary>
        /// <typeparam name="TQuery">The query type to handle</typeparam>
        /// <typeparam name="TResult">The expected result of the query</typeparam>
        /// <param name="query">The query to handle</param>
        /// <returns>Awaitable task for query handling completion with the result</returns>
        Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query)
            where TQuery : IQuery;
    }
}
using System.Threading.Tasks;

namespace LightOps.CQRS.Api.Queries
{
    /// <summary>
    /// Query handler for handling queries of type <typeparamref name="TQuery"/> with an expected result of type <typeparamref name="TResult"/> 
    /// </summary>
    /// <typeparam name="TQuery">The query type to handle</typeparam>
    /// <typeparam name="TResult">The expected result of the query</typeparam>
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery
    {
        /// <summary>
        /// Handles query of type <typeparamref name="TQuery"/> async with an expected result of type <typeparamref name="TResult"/> 
        /// </summary>
        /// <param name="query">The query to handle</param>
        /// <returns>Awaitable task for query handling completion with the result</returns>
        Task<TResult> HandleAsync(TQuery query);
    }
}
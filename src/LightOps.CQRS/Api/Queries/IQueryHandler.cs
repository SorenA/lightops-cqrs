using System.Threading.Tasks;

namespace LightOps.CQRS.Api.Queries
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
using System;
using System.Threading.Tasks;
using LightOps.CQRS.Api.Queries;
using LightOps.CQRS.Api.Services;
using LightOps.CQRS.Domain.Exceptions;

namespace LightOps.CQRS.Domain.Services
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query)
            where TQuery : IQuery
        {
            // Resolve query handler
            var handler = _serviceProvider.GetService(typeof(IQueryHandler<TQuery, TResult>)) as IQueryHandler<TQuery, TResult>;
            if (handler == null)
            {
                throw new QueryHandlerNotFoundException(typeof(TQuery), typeof(TResult));
            }

            return await handler.HandleAsync(query);
        }
    }
}
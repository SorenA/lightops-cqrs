using System;

namespace LightOps.CQRS.Domain.Exceptions
{
    public class QueryHandlerNotFoundException : Exception
    {
        private readonly Type _queryType;
        private readonly Type _resultType;

        public QueryHandlerNotFoundException(Type queryType, Type resultType, string message = null)
            : base(message ?? $"QueryHandler not found for Query {queryType} with result {resultType}.")
        {
            _queryType = queryType;
            _resultType = resultType;
        }
    }
}
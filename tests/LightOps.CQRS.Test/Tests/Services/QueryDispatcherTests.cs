using System.Threading.Tasks;
using LightOps.CQRS.Api.Queries;
using LightOps.CQRS.Domain.Exceptions;
using LightOps.CQRS.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LightOps.CQRS.Test.Tests.Services
{
    public class QueryDispatcherTests
    {
        public class TestQuery : IQuery
        {
            public string Value { get; set; }
        }

        public class TestResult
        {
            public string Value { get; set; }
        }

        public class TestQueryHandler : IQueryHandler<TestQuery, TestResult>
        {
            public Task<TestResult> HandleAsync(TestQuery query)
            {
                return Task.FromResult(new TestResult
                {
                    Value = query.Value,
                });
            }
        }

        [Fact]
        public void TestDispatch_QueryHandlerNotFound()
        {
            var services = new ServiceCollection();
            var serviceProvider = services.BuildServiceProvider();

            var dispatcher = new QueryDispatcher(serviceProvider);

            var query = new TestQuery
            {
                Value = "value",
            };

            Assert.ThrowsAsync<QueryHandlerNotFoundException>(() => dispatcher.DispatchAsync<TestQuery, TestResult>(query));
        }

        [Fact]
        public async Task TestDispatch_QueryHandlerFound()
        {
            var services = new ServiceCollection();
            services.AddScoped<IQueryHandler<TestQuery, TestResult>, TestQueryHandler>();
            var serviceProvider = services.BuildServiceProvider();

            var dispatcher = new QueryDispatcher(serviceProvider);

            var query = new TestQuery
            {
                Value = "value",
            };

            var result = await dispatcher.DispatchAsync<TestQuery, TestResult>(query);
            Assert.NotNull(result);
            Assert.Equal("value", result.Value);
        }
    }
}
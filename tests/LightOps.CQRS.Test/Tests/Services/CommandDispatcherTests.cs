using System.Threading.Tasks;
using LightOps.CQRS.Api.Commands;
using LightOps.CQRS.Domain.Exceptions;
using LightOps.CQRS.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LightOps.CQRS.Test.Tests.Services
{
    public class CommandDispatcherTests
    {
        public class TestCommand : ICommand
        {
            public string Value { get; set; }
        }

        public class TestCommandHandler : ICommandHandler<TestCommand>
        {
            public async Task HandleAsync(TestCommand command)
            {
                await Task.Yield();
            }
        }

        [Fact]
        public void TestDispatch_CommandHandlerNotFound()
        {
            var services = new ServiceCollection();
            var serviceProvider = services.BuildServiceProvider();

            var dispatcher = new CommandDispatcher(serviceProvider);

            var command = new TestCommand
            {
                Value = "value",
            };

            Assert.ThrowsAsync<CommandHandlerNotFoundException>(() => dispatcher.DispatchAsync(command));
        }

        [Fact]
        public async Task TestDispatch_CommandHandlerFound()
        {
            var services = new ServiceCollection();
            services.AddScoped<ICommandHandler<TestCommand>, TestCommandHandler>();
            var serviceProvider = services.BuildServiceProvider();

            var dispatcher = new CommandDispatcher(serviceProvider);

            var command = new TestCommand
            {
                Value = "value",
            };

            var exception = await Record.ExceptionAsync(() => dispatcher.DispatchAsync(command));
            Assert.Null(exception);
        }
    }
}
using LightOps.CQRS.Api.Services;
using LightOps.CQRS.Configuration;
using LightOps.CQRS.Test.Mock;
using LightOps.DependencyInjection.Api.Providers;
using LightOps.DependencyInjection.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LightOps.CQRS.Test.Tests
{
    public class ComponentTests
    {
        [Fact]
        public void TestComponent_IsAttached()
        {
            var services = new ServiceCollection();

            // Add component
            services.AddLightOpsDependencyInjection(root =>
            {
                root.AddCqrs();
            });

            var serviceProvider = services.BuildServiceProvider();

            // Get component state provider
            var dependencyInjectionComponentStateProvider = serviceProvider.GetService<IDependencyInjectionComponentStateProvider>();

            Assert.Contains("lightops.cqrs",
                dependencyInjectionComponentStateProvider.AttachedComponentNames);
        }

        [Fact]
        public void TestComponent_Configuration_Invoked()
        {
            var services = new ServiceCollection();

            // Add component
            var invoked = false;
            services.AddLightOpsDependencyInjection(root =>
            {
                root.AddCqrs(component =>
                {
                    invoked = true;
                });
            });

            var serviceProvider = services.BuildServiceProvider();

            Assert.True(invoked);
        }

        [Fact]
        public void TestComponent_Override_CommandDispatcher()
        {
            var services = new ServiceCollection();

            // Add component
            services.AddLightOpsDependencyInjection(root =>
            {
                root.AddCqrs(component =>
                {
                    component.OverrideCommandDispatcher<NullCommandDispatcher>();
                });
            });

            var serviceProvider = services.BuildServiceProvider();

            Assert.IsType<NullCommandDispatcher>(serviceProvider.GetService<ICommandDispatcher>());
        }

        [Fact]
        public void TestComponent_Override_QueryDispatcher()
        {
            var services = new ServiceCollection();

            // Add component
            services.AddLightOpsDependencyInjection(root =>
            {
                root.AddCqrs(component =>
                {
                    component.OverrideQueryDispatcher<NullQueryDispatcher>();
                });
            });

            var serviceProvider = services.BuildServiceProvider();

            Assert.IsType<NullQueryDispatcher>(serviceProvider.GetService<IQueryDispatcher>());
        }
    }
}
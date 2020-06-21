using System.Collections.Generic;
using System.Linq;
using LightOps.CQRS.Api.Services;
using LightOps.CQRS.Domain.Services;
using LightOps.DependencyInjection.Api.Configuration;
using LightOps.DependencyInjection.Domain.Configuration;

namespace LightOps.CQRS.Configuration
{
    public class CqrsComponent : IDependencyInjectionComponent, ICqrsComponent
    {
        public string Name => "lightops.cqrs";

        public IReadOnlyList<ServiceRegistration> GetServiceRegistrations()
        {
            return new List<ServiceRegistration>()
                .Union(_services.Values)
                .ToList();
        }

        #region Services
        internal enum Services
        {
            CommandDispatcher,
            QueryDispatcher,
        }

        private readonly Dictionary<Services, ServiceRegistration> _services = new Dictionary<Services, ServiceRegistration>
        {
            [Services.CommandDispatcher] = ServiceRegistration.Scoped<ICommandDispatcher, CommandDispatcher>(),
            [Services.QueryDispatcher] = ServiceRegistration.Scoped<IQueryDispatcher, QueryDispatcher>(),
        };

        public ICqrsComponent OverrideCommandDispatcher<T>()
            where T : ICommandDispatcher
        {
            _services[Services.CommandDispatcher].ImplementationType = typeof(T);
            return this;
        }

        public ICqrsComponent OverrideQueryDispatcher<T>()
            where T : IQueryDispatcher
        {
            _services[Services.QueryDispatcher].ImplementationType = typeof(T);
            return this;
        }
        #endregion Services
    }
}
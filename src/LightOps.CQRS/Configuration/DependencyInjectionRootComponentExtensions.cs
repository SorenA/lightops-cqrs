using System;
using LightOps.DependencyInjection.Configuration;

namespace LightOps.CQRS.Configuration
{
    public static class DependencyInjectionRootComponentExtensions
    {
        public static IDependencyInjectionRootComponent AddCqrs(this IDependencyInjectionRootComponent rootComponent, Action<ICqrsComponent> componentConfig = null)
        {
            var component = new CqrsComponent();

            // Invoke config delegate
            componentConfig?.Invoke(component);

            // Attach to root component
            rootComponent.AttachComponent(component);

            return rootComponent;
        }
    }
}
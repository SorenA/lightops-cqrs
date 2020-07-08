# LightOps.CQRS

CQRS package for .NET Standard.

![Nuget](https://img.shields.io/nuget/v/LightOps.CQRS)

| Branch | CI |
| --- | --- |
| master | ![Build Status](https://dev.azure.com/sorendev/LightOps%20Packages/_apis/build/status/LightOps.CQRS?branchName=master) |
| develop | ![Build Status](https://dev.azure.com/sorendev/LightOps%20Packages/_apis/build/status/LightOps.CQRS?branchName=develop)|

## Concepts

The package defines the following concepts.

### Command and query market interfaces - `ICommand` and `IQuery`

Marker interfaces for commands and queries.

### Command handler interface - `ICommandHandler`

Command handler interface used to resolve handler for a command in the service container.

### Query handler interface - `IQueryHandler`

Query handler interface used to resolve handler for a query and result pair in the service container.

### Command dispatcher - `ICommandDispatcher` and implementation `CommandDispatcher`

Resolves command handler using the `ICommandHandler` interface using the command type in the service container.  
Throws a `CommandHandlerNotFoundException` if no command handler is found.

Dispatch using `ICommandDispatcher.DispatchAsync<TCommand>(TCommand command)`.

### Query dispatcher - `IQueryDispatcher` and implementation `QueryDispatcher`

Resolves query handler using the `IQueryDispatcher` interface using the query and result types in the service container.  
Throws a `QueryHandlerNotFoundException` if no query handler is found.

Dispatch using `IQueryDispatcher.DispatchAsync<TQuery, TResult>(TQuery query)`.

## Attaching the component

Register during startup through the `AddCqrs` extension on `IDependencyInjectionRootComponent`.

```csharp
// Add root component
services.AddLightOpsDependencyInjection(root =>
{
    // Add component
    root.AddCqrs(component =>
    {
        // Configure component
        // ...
    });

    // Register other components
    // ...
});
```

Overrides may be registered in the component configurator action, see `ICqrsComponent` for documentation.

### Required component dependencies

- `LightOps.DependencyInjection` - 0.1.x

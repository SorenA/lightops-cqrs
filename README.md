# LightOps.CQRS

CQRS package for .NET Standard.

![Nuget](https://img.shields.io/nuget/v/LightOps.CQRS)

## Concepts

The package defines the following concepts.

### Command and query market interfaces - `ICommand` and `IQuery`

Marker interfaces for commands and queries.

### Command handler interface - `ICommandHandler`

Command handler interface used to resolve handler for a command in the service provider.

### Query handler interface - `IQueryHandler`

Query handler interface used to resolve handler for a query and result pair in the service provider.

### Command dispatcher - `ICommandDispatcher` and implementation `CommandDispatcher`

Resolves command handler using the `ICommandHandler` interface using the command type in the service provider.  
Throws a `CommandHandlerNotFoundException` if no command handler is found.

Dispatch using `ICommandDispatcher.DispatchAsync<TCommand>(TCommand command)`.

### Query dispatcher - `IQueryDispatcher` and implementation `QueryDispatcher`

Resolves query handler using the `IQueryDispatcher` interface using the query and result types in the service provider.  
Throws a `QueryHandlerNotFoundException` if no query handler is found.

Dispatch using `IQueryDispatcher.DispatchAsync<TQuery, TResult>(TQuery query)`.

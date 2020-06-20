# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

- None

## [0.1.0] - 2020-06-20

### Added

- CHANGELOG file
- README file describing project
- Azure Pipelines based CI/CD setup
- `ICommand` marker interface for commands
- `ICommandHandler` interface for implementing command handlers
- `ICommandDispatcher` and implementation `CommandDispatcher` to dispatch and handle
commands using `ICommandHandler`s in service provider
- `IQuery` marker interface for queries
- `IQueryHandler` interface for implementing query handlers
- `IQueryDispatcher` and implementation `QueryDispatcher` to dispatch and handle
queries using `IQueryHandler`s in service provider

[unreleased]: https://github.com/SorenA/lightops-cqrs/compare/0.1.0...develop
[0.1.0]: https://github.com/SorenA/lightops-cqrs/tree/0.1.0

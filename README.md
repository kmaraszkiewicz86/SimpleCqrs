# SimpleCqrs
Lightweight package to work with CQRS handlers and simple mediator class to easly work with CQRS

## Interfaces

- `IQuery<TResult>`: Represents a query that produces a result of the specified type for synchronous execution.
- `IQueryHandler<TQuery, TResult>`: Defines a contract for handling queries and returning results for synchronous execution.
- `IAsyncQueryHandler<TQuery, TResult>`: Defines a contract for handling queries asynchronously.
- `ICommand<out TResult>`: Represents an operation or action that can be executed to produce a result for synchronous execution..
- `ICommandHandler<TCommand>`: Defines a handler for processing commands of a specific type and returning a result for synchronous execution.
- `IAsyncCommandHandler<TCommand>`: Defines a handler for processing asynchronous commands.
- `ISimpleMediator`: Defines a mediator interface for handling queries and commands in a decoupled manner.

## SimpleMediator

- `SimpleMediator(Assembly handlersAssembly)`: Pass the assembly containing your handler implementations.
- `TResult GetQuery<TResult>(IQuery<TResult> query)`: Executes the specified query synchronous and returns the result.
- `Task<TResult> GetQueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)`: Executes the specified query asynchronously and returns the result.
- `TResult SendCommand<TResult>(ICommand<TResult> command)`: Sends a command to the appropriate handler for synchronous processing.
- `Task<TResult> SendCommandAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default)`: Sends a command to the appropriate handler for asynchronous processing.

## Notes

- Handlers are resolved via reflection. Each handler must have a public parameterless constructor.
- Only one handler per query/command type is supported per assembly.

## License

MIT

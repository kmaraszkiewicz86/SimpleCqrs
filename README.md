# SimpleCqrs
Lightweight package to work with CQRS handlers and simple mediator class to easly work with CQRS

## Interfaces

- `IQuery<TResult>`: Marker for queries.
- `IQueryHandler<TQuery, TResult>`: Synchronous query handler.
- `IAsyncQueryHandler<TQuery, TResult>`: Asynchronous query handler.
- `ICommand`: Marker for commands.
- `ICommandHandler<TCommand>`: Synchronous command handler.
- `IAsyncCommandHandler<TCommand>`: Asynchronous command handler.

## SimpleMediator

- `SimpleMediator(Assembly handlersAssembly)`: Pass the assembly containing your handler implementations.
- `TResult GetQuery<TResult>(IQuery<TResult> query)`: Execute a synchronous query.
- `Task<TResult> GetQueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)`: Execute an asynchronous query.
- `void SendCommand(ICommand command)`: Execute a synchronous command.
- `Task SendCommandAsync(ICommand command, CancellationToken cancellationToken = default)`: Execute an asynchronous command.

## Notes

- Handlers are resolved via reflection. Each handler must have a public parameterless constructor.
- Only one handler per query/command type is supported per assembly.

## License

MIT
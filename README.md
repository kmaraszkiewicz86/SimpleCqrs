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

---

## Usage Examples
### 1. Asynchronous Command Handler (`SampleAsyncCommandHandler` + `SampleCommand`)  
```
    public class SampleCommand : ICommand<VoidResult>
    {
        public int Id { get; set; }
    }

        public class SampleAsyncCommandHandler : IAsyncCommandHandler<SampleCommand, VoidResult>
    {
        public async Task<VoidResult> HandleAsync(SampleCommand command, CancellationToken cancellationToken = default)
        {
            return new VoidResult();
        }
    }
```

### 2. Synchronous Command Handler (`SampleCommandHandler`)  
```
    public class SampleCommandHandler : ICommandHandler<SampleCommand, VoidResult>
    {
        public VoidResult Handle(SampleCommand command)
        {
            return new VoidResult();
        }
    }
```

### 3. Asynchronous Command Handler With Result (`SampleCommandWithResultHandler` + `SampleCommandWithResult`)
```
    public class SampleCommandWithResult : ICommand<int>
    {
        public int Id { get; set; }
    }

    public class SampleCommandWithResultHandler : ICommandHandler<SampleCommandWithResult, int>
    {
        public int Handle(SampleCommandWithResult command)
        {
            // Example logic: return the Id incremented
            Console.WriteLine($"Handled SampleCommandWithResult synchronously with Id: {command.Id}");
            return command.Id + 100;
        }
    }
```

### 4. Synchronous Query Handler (`SampleCommandWithResultHandler` + `SampleQuery`)
```
    public class SampleQuery : IQuery<SampleResult>
    {
        public int Id { get; set; }
    }

    public class SampleQueryHandler : IQueryHandler<SampleQuery, SampleResult>
    {
        public SampleResult Handle(SampleQuery query)
        {
            // Example logic: return the Id incremented
            return new(query.Id + 1, "Test");
        }
    }
```

### 5. Asynchronous Query Handler (`SampleAsyncQueryHandler`)
```
    public class SampleAsyncQueryHandler : IAsyncQueryHandler<SampleQuery, SampleResult>
    {
        public async Task<SampleResult> HandleAsync(SampleQuery query, CancellationToken cancellationToken = default)
        {
            // Example async logic: simulate async work and return the Id incremented
            await Task.Delay(100, cancellationToken);
            return new (query.Id + 1, "Test");
        }
    }
```

### 6. Dependency Injection example (Microsoft.Extensions.DependencyInjection)
```
    services.AddScoped<ISimpleMediator>(scope => new SimpleMediator(typeof(GetRosaryForTodayQueryHandler).Assembly));
```

## Notes

- Handlers are resolved via reflection. Each handler must have a public parameterless constructor.
- Only one handler per query/command type is supported per assembly.

## The demo app with examples

The demo app with examples is located [here](https://github.com/kmaraszkiewicz86/SimpleCqrs/tree/main/src/SimpleCqrs.Console.Demo).

## License

MIT

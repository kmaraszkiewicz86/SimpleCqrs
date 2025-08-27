using SimpleCqrs;
using SimpleCqrs.ConsoleApp.Demo.Cqrs.Commands;
using SimpleCqrs.ConsoleApp.Demo.Cqrs.Queries;

SimpleMediator simpleMediator = new (typeof(Program).Assembly);

SampleCommand sampleCommand = new() { Id = 1 };
SampleCommandWithResult sampleCommandWithResult = new() { Id = 1 };
SampleQuery sampleQuery = new() { Id = 1 };

SampleResult queryResult = simpleMediator.GetQuery(sampleQuery);
SampleResult queryResult2 = await simpleMediator.GetQueryAsync(sampleQuery, CancellationToken.None);

Console.WriteLine($"Sync Query Result: {queryResult.Id}");
Console.WriteLine($"Async Query Result: {queryResult2.Id}");

simpleMediator.SendCommand(sampleCommand);
await simpleMediator.SendCommandAsync(sampleCommand);

int commandResult = simpleMediator.SendCommand(sampleCommandWithResult);
int commandResult2 = await simpleMediator.SendCommandAsync(sampleCommandWithResult);

Console.WriteLine($"Sync Command Result: {commandResult}");
Console.WriteLine($"Async Command Result: {commandResult2}");
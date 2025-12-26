using SimpleCqrs.ConsoleApp.Demo.Cqrs.Commands;
using SimpleCqrs.ConsoleApp.Demo.Cqrs.Queries;
using SimpleCqrs.ConsoleApp.Demo.Models.Cqrs.Commands;
namespace SimpleCqrs.ConsoleApp.Demo
{
    public class SimpleMediatorSampleService(ISimpleMediator simpleMediator) : ISimpleMediatorSampleService
    {
        public async Task RunDemoAsync()
        {
            await RunQueries();
            await RunCommandsAsync();
            await RunCommandsWithCommandsFromOtherProject();
        }

        private async Task RunQueries()
        {
            //SampleQuery sampleQuery = new() { Id = 1 };

            //SampleResult queryResult = simpleMediator.GetQuery(sampleQuery);
            //SampleResult queryResult2 = await simpleMediator.GetQueryAsync(sampleQuery, CancellationToken.None);

            //Console.WriteLine($"Sync Query Result: {queryResult.Id}");
            //Console.WriteLine($"Async Query Result: {queryResult2.Id}");
        }

        private async Task RunCommandsAsync()
        {
            //SampleCommand sampleCommand = new() { Id = 1 };
            //SampleWithResultCommand sampleCommandWithResult = new() { Id = 1 };

            //simpleMediator.SendCommand(sampleCommand);
            //await simpleMediator.SendCommandAsync(sampleCommand);

            //int commandResult = simpleMediator.SendCommand(sampleCommandWithResult);
            //int commandResult2 = await simpleMediator.SendCommandAsync(sampleCommandWithResult);

            //Console.WriteLine($"Sync Command Result: {commandResult}");
            //Console.WriteLine($"Async Command Result: {commandResult2}");
        }

        private async Task RunCommandsWithCommandsFromOtherProject()
        {
            SampleWithResultInOtherProjectCommand sampledWithResultInOtherProjectCommand = new() { Id = 1 };
            SampleWithResultInOtherProjectAsyncCommand sampledWithResultInOtherProjectAsyncCommand = new() { Id = 2 };

            int commandResult3 = simpleMediator.SendCommand(sampledWithResultInOtherProjectCommand);
            int commandResult4 = await simpleMediator.SendCommandAsync(sampledWithResultInOtherProjectAsyncCommand);
            Console.WriteLine($"Async Command Result (Other Project): {commandResult3}");
        }
    }
}

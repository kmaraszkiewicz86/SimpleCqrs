namespace SimpleCqrs.ConsoleApp.Demo.Cqrs.Commands.Handlers
{
    // Asynchronous command handler for command with int result
    public class SampleAsyncWithResultCommandHandler : IAsyncCommandHandler<SampleWithResultCommand, int>
    {
        public async Task<int> HandleAsync(SampleWithResultCommand command, CancellationToken cancellationToken = default)
        {
            // Example async logic: simulate async work and return the Id incremented
            await Task.Delay(100, cancellationToken);
            Console.WriteLine($"Handled SampleWithResultCommand asynchronously with Id: {command.Id}");
            return command.Id + 200;
        }
    }
}

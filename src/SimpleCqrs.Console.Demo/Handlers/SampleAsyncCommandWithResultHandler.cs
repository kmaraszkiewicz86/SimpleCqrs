namespace SimpleCqrs.ConsoleApp.Demo.Handlers
{
    // Asynchronous command handler for command with int result
    public class SampleAsyncCommandWithResultHandler : IAsyncCommandHandler<SampleCommandWithResult, int>
    {
        public async Task<int> HandleAsync(SampleCommandWithResult command, CancellationToken cancellationToken = default)
        {
            // Example async logic: simulate async work and return the Id incremented
            await Task.Delay(100, cancellationToken);
            Console.WriteLine($"Handled SampleCommandWithResult asynchronously with Id: {command.Id}");
            return command.Id + 200;
        }
    }
}

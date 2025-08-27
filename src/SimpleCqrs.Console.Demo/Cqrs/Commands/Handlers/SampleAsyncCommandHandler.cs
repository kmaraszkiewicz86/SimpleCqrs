namespace SimpleCqrs.ConsoleApp.Demo.Cqrs.Commands.Handlers
{
    // Asynchronous command handler example
    public class SampleAsyncCommandHandler : IAsyncCommandHandler<SampleCommand, VoidResult>
    {
        public async Task<VoidResult> HandleAsync(SampleCommand command, CancellationToken cancellationToken = default)
        {
            // Example async logic: simulate async work
            await Task.Delay(100, cancellationToken);
            Console.WriteLine($"Handled SampleCommand asynchronously with Id: {command.Id}");
            return new VoidResult();
        }
    }
}

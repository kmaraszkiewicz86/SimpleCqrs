namespace SimpleCqrs.ConsoleApp.Demo.Handlers
{
    // Synchronous command handler example
    public class SampleCommandHandler : ICommandHandler<SampleCommand, VoidResult>
    {
        public VoidResult Handle(SampleCommand command)
        {
            // Example logic: print the command Id
            Console.WriteLine($"Handled SampleCommand synchronously with Id: {command.Id}");
            return new VoidResult();
        }
    }
}

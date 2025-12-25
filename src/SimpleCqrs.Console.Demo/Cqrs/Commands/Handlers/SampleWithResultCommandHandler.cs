namespace SimpleCqrs.ConsoleApp.Demo.Cqrs.Commands.Handlers
{
    // Synchronous command handler for command with int result
    public class SampleWithResultCommandHandler : ICommandHandler<SampleWithResultCommand, int>
    {
        public int Handle(SampleWithResultCommand command)
        {
            // Example logic: return the Id incremented
            Console.WriteLine($"Handled SampleWithResultCommand synchronously with Id: {command.Id}");
            return command.Id + 100;
        }
    }
}

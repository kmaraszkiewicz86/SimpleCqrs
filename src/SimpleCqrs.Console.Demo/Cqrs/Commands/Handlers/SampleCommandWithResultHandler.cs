namespace SimpleCqrs.ConsoleApp.Demo.Cqrs.Commands.Handlers
{
    // Synchronous command handler for command with int result
    public class SampleCommandWithResultHandler : ICommandHandler<SampleCommandWithResult, int>
    {
        public int Handle(SampleCommandWithResult command)
        {
            // Example logic: return the Id incremented
            Console.WriteLine($"Handled SampleCommandWithResult synchronously with Id: {command.Id}");
            return command.Id + 100;
        }
    }
}

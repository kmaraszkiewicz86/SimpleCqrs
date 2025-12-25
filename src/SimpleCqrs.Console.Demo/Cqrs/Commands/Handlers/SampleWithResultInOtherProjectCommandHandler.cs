using SimpleCqrs.ConsoleApp.Demo.Models.Cqrs.Commands;

namespace SimpleCqrs.ConsoleApp.Demo.Cqrs.Commands.Handlers
{
    public class SampleWithResultInOtherProjectCommandHandler : ICommandHandler<SampleWithResultInOtherProjectCommand, int>
    {
        public int Handle(SampleWithResultInOtherProjectCommand command)
        {
            // Example logic: return the Id incremented
            Console.WriteLine($"Handled SampleCommandWithResult synchronously with Id: {command.Id}");
            return command.Id + 100;
        }
    }
}

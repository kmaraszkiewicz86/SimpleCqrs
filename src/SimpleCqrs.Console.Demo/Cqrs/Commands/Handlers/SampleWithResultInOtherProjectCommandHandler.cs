using SimpleCqrs.ConsoleApp.Demo.Models.Cqrs.Commands;
using SimpleCqrs.ConsoleApp.Demo.Services;

namespace SimpleCqrs.ConsoleApp.Demo.Cqrs.Commands.Handlers
{
    public class SampleWithResultInOtherProjectCommandHandler(ISampleService service) : ICommandHandler<SampleWithResultInOtherProjectCommand, int>
    {
        public int Handle(SampleWithResultInOtherProjectCommand command)
        {
            // Example logic: return the Id incremented
            Console.WriteLine(service.GetData(command.Id));
            return command.Id + 100;
        }
    }
}

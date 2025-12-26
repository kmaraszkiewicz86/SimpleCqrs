using SimpleCqrs.ConsoleApp.Demo.Models.Cqrs.Commands;
using SimpleCqrs.ConsoleApp.Demo.Services;

namespace SimpleCqrs.ConsoleApp.Demo.Cqrs.Commands.Handlers
{
    public class SampleWithResultInOtherProjectAsyncCommandHandler(ISampleService service) : IAsyncCommandHandler<SampleWithResultInOtherProjectAsyncCommand, int>
    {
        public async Task<int> HandleAsync(SampleWithResultInOtherProjectAsyncCommand command, CancellationToken cancellationToken = default)
        {
            // Example logic: return the Id incremented
            Console.WriteLine(await service.GetDataAsync(command.Id));
            return command.Id + 100;
        }
    }
}

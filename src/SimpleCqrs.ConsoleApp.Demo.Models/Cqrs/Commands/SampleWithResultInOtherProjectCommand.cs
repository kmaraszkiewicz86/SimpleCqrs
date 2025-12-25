namespace SimpleCqrs.ConsoleApp.Demo.Models.Cqrs.Commands
{
    public class SampleWithResultInOtherProjectCommand : ICommand<int>
    {
        public int Id { get; set; }
    }
}

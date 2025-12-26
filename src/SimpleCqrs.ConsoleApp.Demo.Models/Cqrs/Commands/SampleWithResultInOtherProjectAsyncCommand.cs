namespace SimpleCqrs.ConsoleApp.Demo.Models.Cqrs.Commands
{
    public class SampleWithResultInOtherProjectAsyncCommand : ICommand<int>
    {
        public int Id { get; set; }
    }
}

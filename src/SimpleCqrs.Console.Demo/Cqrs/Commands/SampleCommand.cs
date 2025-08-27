namespace SimpleCqrs.ConsoleApp.Demo.Cqrs.Commands
{
    // Sample command
    public class SampleCommand : ICommand<VoidResult>
    {
        public int Id { get; set; }
    }
}

namespace SimpleCqrs.ConsoleApp.Demo.Handlers
{
    // Sample command
    public class SampleCommand : ICommand<VoidResult>
    {
        public int Id { get; set; }
    }
}

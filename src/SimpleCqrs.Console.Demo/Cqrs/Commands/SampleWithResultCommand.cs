namespace SimpleCqrs.ConsoleApp.Demo.Cqrs.Commands
{
    // Command with int result
    public class SampleWithResultCommand : ICommand<int>
    {
        public int Id { get; set; }
    }
}

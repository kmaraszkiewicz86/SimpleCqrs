namespace SimpleCqrs.ConsoleApp.Demo.Cqrs.Commands
{
    // Command with int result
    public class SampleCommandWithResult : ICommand<int>
    {
        public int Id { get; set; }
    }
}

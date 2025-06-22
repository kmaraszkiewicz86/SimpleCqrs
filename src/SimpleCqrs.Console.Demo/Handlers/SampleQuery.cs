namespace SimpleCqrs.ConsoleApp.Demo.Handlers
{
    // Sample query
    public class SampleQuery : IQuery<SampleResult>
    {
        public int Id { get; set; }
    }
}

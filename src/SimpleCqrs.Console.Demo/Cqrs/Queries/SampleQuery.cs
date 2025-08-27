namespace SimpleCqrs.ConsoleApp.Demo.Cqrs.Queries
{
    // Sample query
    public class SampleQuery : IQuery<SampleResult>
    {
        public int Id { get; set; }
    }
}

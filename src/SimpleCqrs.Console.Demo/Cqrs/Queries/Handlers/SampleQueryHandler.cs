namespace SimpleCqrs.ConsoleApp.Demo.Cqrs.Queries.Handlers
{
    // Synchronous query handler example
    public class SampleQueryHandler : IQueryHandler<SampleQuery, SampleResult>
    {
        public SampleResult Handle(SampleQuery query)
        {
            // Example logic: return the Id incremented
            return new(query.Id + 1, "Test");
        }
    }
}

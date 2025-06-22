namespace SimpleCqrs.ConsoleApp.Demo.Handlers
{
    // Asynchronous query handler example
    public class SampleAsyncQueryHandler : IAsyncQueryHandler<SampleQuery, SampleResult>
    {
        public async Task<SampleResult> HandleAsync(SampleQuery query, CancellationToken cancellationToken = default)
        {
            // Example async logic: simulate async work and return the Id incremented
            await Task.Delay(100, cancellationToken);
            return new (query.Id + 1, "Test");
        }
    }
}

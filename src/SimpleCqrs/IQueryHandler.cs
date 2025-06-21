namespace SimpleCqrs
{
    /// <summary>
    /// Synchronous query handler
    /// </summary>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
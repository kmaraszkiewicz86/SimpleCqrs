namespace SimpleCqrs
{
    /// <summary>
    /// Represents a query that produces a result of the specified type for synchronous execution.
    /// </summary>
    /// <typeparam name="TResult">The type of the result produced by the query.</typeparam>
    public interface IQuery<TResult> { }
}
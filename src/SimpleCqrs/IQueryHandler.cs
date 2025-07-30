namespace SimpleCqrs
{
    /// <summary>
    /// Defines a contract for handling queries and returning results for synchronous execution.
    /// </summary>
    /// <remarks>Implementations of this interface are responsible for processing a specific type of query and
    /// returning the corresponding result. This interface is typically used in applications following the CQRS (Command
    /// Query Responsibility Segregation) pattern.</remarks>
    /// <typeparam name="TQuery">The type of the query to be handled. Must implement <see cref="IQuery{TResult}"/>.</typeparam>
    /// <typeparam name="TResult">The type of the result produced by the query.</typeparam>
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
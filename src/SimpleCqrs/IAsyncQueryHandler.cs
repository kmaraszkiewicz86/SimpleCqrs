using System.Threading;
using System.Threading.Tasks;

namespace SimpleCqrs
{
    /// <summary>
    /// Defines a contract for handling queries asynchronously.
    /// </summary>
    /// <remarks>Implementations of this interface are responsible for processing queries of type
    /// <typeparamref name="TQuery"/>  and returning a result of type <typeparamref name="TResult"/>. This is typically
    /// used in CQRS patterns to  separate query handling logic from other application concerns.</remarks>
    /// <typeparam name="TQuery">The type of the query to be handled. Must implement <see cref="IQuery{TResult}"/>.</typeparam>
    /// <typeparam name="TResult">The type of the result produced by the query.</typeparam>
    public interface IAsyncQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
    }
}
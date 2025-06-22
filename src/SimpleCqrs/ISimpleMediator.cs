using System.Threading;
using System.Threading.Tasks;

namespace SimpleCqrs
{
    /// <summary>
    /// Defines a mediator interface for handling queries and commands in a decoupled manner.
    /// </summary>
    /// <remarks>The <see cref="ISimpleMediator"/> interface provides methods for executing queries and
    /// commands,  both synchronously and asynchronously. It is designed to facilitate communication between  different
    /// parts of an application without requiring direct dependencies.</remarks>
    public interface ISimpleMediator
    {
        /// <summary>
        /// Executes the specified query synchronous and returns the result.
        /// </summary>
        /// <remarks>This method dynamically resolves the appropriate query handler for the provided query
        /// type and invokes its <c>Handle</c> method to process the query. Ensure that a compatible query handler is
        /// registered and available for the query type.</remarks>
        /// <typeparam name="TResult">The type of the result produced by the query.</typeparam>
        /// <param name="query">The query to be executed. Must implement <see cref="IQuery{TResult}"/>.</param>
        /// <returns>The result of the query execution.</returns>
        TResult GetQuery<TResult>(IQuery<TResult> query);

        /// <summary>
        /// Executes the specified query asynchronously and returns the result.
        /// </summary>
        /// <remarks>This method dynamically resolves and invokes the appropriate query handler for the
        /// given query. Ensure that a compatible handler is registered and accessible.</remarks>
        /// <typeparam name="TResult">The type of the result produced by the query.</typeparam>
        /// <param name="query">The query to be executed. Must implement <see cref="IQuery{TResult}"/>.</param>
        /// <param name="cancellationToken">A token that can be used to cancel the operation. Defaults to <see cref="CancellationToken.None"/> if not
        /// provided.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the result of the query.</returns>
        Task<TResult> GetQueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a command to the appropriate handler for synchronous processing.
        /// </summary>
        /// <remarks>This method locates the appropriate handler for the specified command type and
        /// invokes its <c>Handle</c> method. Ensure that a corresponding handler implementing
        /// <c>ICommandHandler{TCommand, TResult}</c> is registered and available.</remarks>
        /// <typeparam name="TResult">The type of the result expected from the command.</typeparam>
        /// <param name="command">The command to be processed. Must implement <see cref="ICommand{TResult}"/>.</param>
        /// <returns>The result of the result of the command. Use <see cref="VoidResult" > for empty result</see></returns>
        TResult SendCommand<TResult>(ICommand<TResult> command);

        /// <summary>
        /// Sends a command to the appropriate handler for asynchronous processing.
        /// </summary>
        /// <remarks>This method dynamically resolves the appropriate handler for the specified command
        /// type and invokes its asynchronous processing logic. Ensure that a compatible handler is registered for the
        /// command type before calling this method.</remarks>
        /// <typeparam name="TResult">The type of the result returned by the command.</typeparam>
        /// <param name="command">The command to be processed. Cannot be <see langword="null"/>.</param>
        /// <param name="cancellationToken">A token that can be used to cancel the operation. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the result of the command. Use <see cref="VoidResult" > for empty result</see></returns>
        Task<TResult> SendCommandAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);
    }
}
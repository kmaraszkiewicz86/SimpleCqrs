using System.Threading;
using System.Threading.Tasks;

namespace SimpleCqrs
{
    /// <summary>
    /// Defines a handler for processing asynchronous commands.
    /// </summary>
    /// <remarks>Implementations of this interface are responsible for executing the logic associated with a
    /// specific command. This interface is typically used in command-based architectures to decouple the sender of a
    /// command from its execution.</remarks>
    /// <typeparam name="TCommand">The type of the command to be handled. Must implement <see cref="ICommand{TResult}"/>.</typeparam>
    /// <typeparam name="TResult">The type of the result produced by the command. Use <see cref="VoidResult"/> for command with empty result</typeparam>
    public interface IAsyncCommandHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
    }
}
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCqrs
{
    /// <summary>
    /// Asynchronous command handler
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public interface IAsyncCommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
    }
}
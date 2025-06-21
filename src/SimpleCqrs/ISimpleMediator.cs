using System.Threading;
using System.Threading.Tasks;

namespace SimpleCqrs
{
    /// <summary>
    /// Interface for the SimpleMediator CQRS mediator.
    /// </summary>
    public interface ISimpleMediator
    {
        TResult GetQuery<TResult>(IQuery<TResult> query);
        Task<TResult> GetQueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
        void SendCommand(ICommand command);
        Task SendCommandAsync(ICommand command, CancellationToken cancellationToken = default);
    }
}
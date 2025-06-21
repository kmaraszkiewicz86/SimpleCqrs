using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCqrs
{

    /// <summary>
    /// Simple mediator for CQRS
    /// </summary>
    public class SimpleMediator : ISimpleMediator
    {
        private readonly Assembly _handlersAssembly;

        public SimpleMediator(Assembly handlersAssembly)
        {
            _handlersAssembly = handlersAssembly ?? throw new ArgumentNullException(nameof(handlersAssembly));
        }

        public TResult GetQuery<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            var handler = FindHandler(handlerType);
            return (TResult)handlerType.GetMethod("Handle").Invoke(handler, new object[] { query });
        }

        public Task<TResult> GetQueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
        {
            var handlerType = typeof(IAsyncQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            var handler = FindHandler(handlerType);
            return (Task<TResult>)handlerType.GetMethod("HandleAsync").Invoke(handler, new object[] { query, cancellationToken });
        }

        public void SendCommand(ICommand command)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            var handler = FindHandler(handlerType);
            handlerType.GetMethod("Handle").Invoke(handler, new object[] { command });
        }

        public Task SendCommandAsync(ICommand command, CancellationToken cancellationToken = default)
        {
            var handlerType = typeof(IAsyncCommandHandler<>).MakeGenericType(command.GetType());
            var handler = FindHandler(handlerType);
            return (Task)handlerType.GetMethod("HandleAsync").Invoke(handler, new object[] { command, cancellationToken });
        }

        private object FindHandler(Type handlerType)
        {
            foreach (var type in _handlersAssembly.GetTypes())
            {
                if (handlerType.IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                {
                    return Activator.CreateInstance(type);
                }
            }
            throw new InvalidOperationException($"Handler for type {handlerType.Name} not found in assembly {_handlersAssembly.FullName}.");
        }
    }
}
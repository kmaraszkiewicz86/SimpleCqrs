using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCqrs
{

    /// <summary>
    /// Provides a mechanism for dispatching queries and commands to their respective handlers.
    /// </summary>
    /// <remarks>The <see cref="SimpleMediator"/> class is designed to facilitate communication between
    /// different parts of an application by dynamically resolving and invoking handlers for queries and commands.
    /// Handlers are discovered within the specified assembly provided during instantiation. <para> This class supports
    /// both synchronous and asynchronous operations for queries and commands. It relies on reflection to locate and
    /// invoke the appropriate handler types. </para> <para> Exceptions may be thrown if a handler cannot be found for a
    /// given query or command, or if the handler invocation fails. </para></remarks>
    public class SimpleMediator : ISimpleMediator
    {
        private readonly Assembly _handlersAssembly;
        private readonly Assembly _modelsAssembly;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleMediator"/> class.
        /// </summary>
        /// <param name="handlersAssembly">The assembly containing the handler types to be used by the mediator. This parameter cannot be <see
        /// langword="null"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="handlersAssembly"/> is <see langword="null"/>.</exception>
        public SimpleMediator(Assembly handlersAssembly)
        {
            _handlersAssembly = handlersAssembly ?? throw new ArgumentNullException(nameof(handlersAssembly));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleMediator"/> class.
        /// </summary>
        /// <param name="handlersAssembly">The assembly containing the handler types to be used by the mediator. This parameter cannot be <see
        /// langword="null"/>.</param>
        /// <param name="modelsAssembly">The assembly containing the command / queries types to be used in the mediator. This parameter cannot be <see
        /// langword="null"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="handlersAssembly"/> is <see langword="null"/>.</exception>
        public SimpleMediator(Assembly handlersAssembly, Assembly modelsAssembly) : this(handlersAssembly)
        {
            _modelsAssembly = modelsAssembly ?? throw new ArgumentNullException(nameof(modelsAssembly));
        }

        /// <summary>
        /// Executes the specified query synchronous and returns the result.
        /// </summary>
        /// <remarks>This method dynamically resolves the appropriate query handler for the provided query
        /// type and invokes its <c>Handle</c> method to process the query. Ensure that a compatible query handler is
        /// registered and available for the query type.</remarks>
        /// <typeparam name="TResult">The type of the result produced by the query.</typeparam>
        /// <param name="query">The query to be executed. Must implement <see cref="IQuery{TResult}"/>.</param>
        /// <returns>The result of the query execution.</returns>
        public TResult GetQuery<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            var handler = CreateHandlerInstance(handlerType);
            return (TResult)handlerType.GetMethod("Handle").Invoke(handler, new object[] { query });
        }

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
        public Task<TResult> GetQueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
        {
            var handlerType = typeof(IAsyncQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            var handler = CreateHandlerInstance(handlerType);
            return (Task<TResult>)handlerType.GetMethod("HandleAsync").Invoke(handler, new object[] { query, cancellationToken });
        }

        /// <summary>
        /// Sends a command to the appropriate handler for synchronous processing.
        /// </summary>
        /// <remarks>This method locates the appropriate handler for the specified command type and
        /// invokes its <c>Handle</c> method. Ensure that a corresponding handler implementing
        /// <c>ICommandHandler{TCommand, TResult}</c> is registered and available.</remarks>
        /// <typeparam name="TResult">The type of the result expected from the command.</typeparam>
        /// <param name="command">The command to be processed. Must implement <see cref="ICommand{TResult}"/>.</param>
        /// <returns>The result of the result of the command. Use <see cref="VoidResult" > for empty result</see></returns>
        public TResult SendCommand<TResult>(ICommand<TResult> command)
        {
            var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));
            var handler = CreateHandlerInstance(handlerType);
            return (TResult)handlerType.GetMethod("Handle").Invoke(handler, new object[] { command });
        }

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
        public Task<TResult> SendCommandAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default)
        {
            var handlerType = typeof(IAsyncCommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));
            var handler = CreateHandlerInstance(handlerType);
            return (Task<TResult>)handlerType.GetMethod("HandleAsync").Invoke(handler, new object[] { command, cancellationToken });
        }

        /// <summary>
        /// Creates an instance of a class that implements or derives from the specified handler type.
        /// </summary>
        /// <remarks>This method searches the assembly for a concrete, non-abstract class that is
        /// assignable to the specified <paramref name="handlerType"/>. If a matching class is found, an instance of the
        /// class is created using <see cref="Activator.CreateInstance(Type)"/>.</remarks>
        /// <param name="handlerType">The type of the handler to locate and instantiate. Must be a non-abstract, non-interface type assignable
        /// from the target class.</param>
        /// <returns>An instance of a class that implements or derives from <paramref name="handlerType"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown if no suitable class implementing or deriving from <paramref name="handlerType"/> is found in the
        /// assembly.</exception>
        private object CreateHandlerInstance(Type handlerType)
        {
            var handlers = new List<Type>(_handlersAssembly.GetTypes());

            //if (_modelsAssembly != null)
            //{
            //    handlers.AddRange(_modelsAssembly.GetTypes());
            //}

            foreach (var type in handlers)
            {
                if (handlerType.IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                {
                    return Activator.CreateInstance(type);
                }
            }

            var errorMessage = $"Handler for type {handlerType.Name} not found in assembly {_handlersAssembly.FullName}." +
                $"{(_modelsAssembly != null ? $" and in assembly {_modelsAssembly.FullName}." : "")}";

            throw new InvalidOperationException(errorMessage);
        }
    }
}
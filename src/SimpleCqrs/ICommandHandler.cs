namespace SimpleCqrs
{
    /// <summary>
    /// Defines a handler for processing commands of a specific type and returning a result for synchronous execution.
    /// </summary>
    /// <remarks>Implementations of this interface encapsulate the logic for handling a specific command type.
    /// This allows for decoupling the command processing logic from other parts of the application.</remarks>
    /// <typeparam name="TCommand">The type of the command to be handled. Must implement <see cref="ICommand{TResult}"/>.</typeparam>
    /// <typeparam name="TResult">The type of the result produced by handling the command. Use <see cref="VoidResult"/> for command with empty result</typeparam>
    public interface ICommandHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        TResult Handle(TCommand command);
    }
}
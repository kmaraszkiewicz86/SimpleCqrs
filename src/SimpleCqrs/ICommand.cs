namespace SimpleCqrs
{
    /// <summary>
    /// Represents an operation or action that can be executed to produce a result for synchronous execution.
    /// </summary>
    /// <remarks>This interface is typically used to define commands in a command-based architecture,  where
    /// commands encapsulate the logic for performing an action and returning a result.</remarks>
    /// <typeparam name="TResult">The type of the result produced by the command.</typeparam>
    public interface ICommand<out TResult> { }
}
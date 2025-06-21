namespace SimpleCqrs
{
    /// <summary>
    /// Synchronous command handler
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
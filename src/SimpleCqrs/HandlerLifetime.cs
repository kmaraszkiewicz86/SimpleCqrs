namespace SimpleCqrs
{
    public static partial class ServiceCollectionExtensions
    {
        public enum HandlerLifetime
        {
            Transient,
            Scoped,
            Singleton
        }
    }

}

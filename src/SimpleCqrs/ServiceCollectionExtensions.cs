using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimpleCqrs
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureSimpleCqrs(
            this IServiceCollection services,
            Assembly handlersAssembly,
            HandlerLifetime scope = HandlerLifetime.Scoped)
        {
            var queryHandlerInterfaceType = typeof(IQueryHandler<,>);
            var handlerInterfaceType = typeof(ICommandHandler<,>);
            var asyncQueryHandlerInterfaceType = typeof(IAsyncQueryHandler<,>);
            var asyncHandlerInterfaceType = typeof(IAsyncCommandHandler<,>);

            // default to transient lifetime
            RegisterCommandHandlers(services, handlersAssembly, handlerInterfaceType, scope);
            RegisterCommandHandlers(services, handlersAssembly, queryHandlerInterfaceType, scope);
            RegisterCommandHandlers(services, handlersAssembly, asyncHandlerInterfaceType, scope);
            RegisterCommandHandlers(services, handlersAssembly, asyncQueryHandlerInterfaceType, scope);

            services.AddScoped<ISimpleMediator>(serviceProvider => new SimpleMediator(serviceProvider,
                handlersAssembly));

            return services;
        }

        private static void RegisterCommandHandlers(
            IServiceCollection services,
            Assembly handlersAssembly,
            Type handlerInterfaceType,
            HandlerLifetime lifetime)
        {
            foreach (var type in handlersAssembly.GetTypes())
            {
                if (type.IsAbstract || type.IsInterface)
                    continue;

                var interfaces = type.GetInterfaces()
                    .Where(i =>
                        i.IsGenericType &&
                        i.GetGenericTypeDefinition() == handlerInterfaceType);

                foreach (var @interface in interfaces)
                {
                    switch (lifetime)
                    {
                        case HandlerLifetime.Scoped:
                            services.AddScoped(@interface, type);
                            break;
                        case HandlerLifetime.Singleton:
                            services.AddSingleton(@interface, type);
                            break;
                        default:
                            services.AddTransient(@interface, type);
                            break;
                    }
                }
            }
        }
    }

}

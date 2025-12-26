using Microsoft.Extensions.DependencyInjection;
using SimpleCqrs;
using SimpleCqrs.ConsoleApp.Demo;
using SimpleCqrs.ConsoleApp.Demo.Services;

var services = new ServiceCollection();

services.AddScoped<ISampleService, SampleService>();
services.ConfigureSimpleCqrs(typeof(Program).Assembly);

services.AddScoped<ISimpleMediator>(serviceProvider => new SimpleMediator(serviceProvider,
    typeof(Program).Assembly));
services.AddScoped<ISimpleMediatorSampleService, SimpleMediatorSampleService>();

using var serviceProvider = services.BuildServiceProvider();

var service = serviceProvider.GetRequiredService<ISimpleMediatorSampleService>();
await service.RunDemoAsync();
using System.Reflection;
using Mediator.Abstractions.Dhionys;
using Microsoft.Extensions.DependencyInjection;

namespace Mediator.Extensions;

public static class MediatorExtension
{
    public static IServiceCollection AddMediator(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddTransient<IMediator, Mediator>();
        
        var handlerInterfaceType = typeof(IHandler<,>);

        foreach (var assembly in assemblies)
        {
            var handlers = assembly
                .GetTypes()
                .Where(type => type is { IsAbstract: false, IsInterface: false })
                .SelectMany(type => type.GetInterfaces(), (type, i) => new { Type = type, Interface = i })
                .Where(interfaceType => interfaceType.Interface.IsGenericType && interfaceType.Interface.GetGenericTypeDefinition() == handlerInterfaceType);

            foreach (var handler in handlers) 
                services.AddTransient(handler.Interface, handler.Type);
        }

        return services;
    }
}
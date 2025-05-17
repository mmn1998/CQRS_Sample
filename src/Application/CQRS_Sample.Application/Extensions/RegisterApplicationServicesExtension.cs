using CQRS_Sample.Application.Commands.Handlers.SomeModels;
using CQRS_Sample.Application.Queries.Handlers.SomeModels;
using CQRS_Sample.Common.MediatRHelpers;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CQRS_Sample.Application.Extensions;

public static class RegisterApplicationServicesExtension
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(c =>
        {
            c.Lifetime = ServiceLifetime.Scoped;
            c.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });
        services.Scan(scan =>
            scan.FromAssemblyOf<SomeModelEventHandler>()
                .AddClasses(classes => classes.AssignableTo(typeof(INotificationHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        services.Scan(scan =>
            scan.FromAssemblyOf<SomeModelQueryHandler>()
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        services.Scan(scan =>
            scan.FromAssemblyOf<SomeModelEventHandler>()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        return services;
    }
}

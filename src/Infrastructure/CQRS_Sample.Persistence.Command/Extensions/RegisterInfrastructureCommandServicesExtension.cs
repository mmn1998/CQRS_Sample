using CQRS_Sample.Persistence.Command.Repositories.SomeModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS_Sample.Persistence.Command.Extensions;

public static class RegisterInfrastructureCommandServicesExtension
{
    public static IServiceCollection RegisterInfrastrucureCommandServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISomeModelCommandRepository, SomeModelCommandRepository>();
        return services;
    }
}

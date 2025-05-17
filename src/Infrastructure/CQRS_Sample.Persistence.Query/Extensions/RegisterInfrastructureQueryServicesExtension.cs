using CQRS_Sample.Persistence.Query.Repositories.SomeModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS_Sample.Persistence.Query.Extensions;

public static class RegisterInfrastructureQueryServicesExtension
{
    public static IServiceCollection RegisterInfrastrucureQueryServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISomeModelQueryRepository, SomeModelQueryRepository>();
        return services;
    }
}

using CQRS_Sample.Persistence.Command.Persistence;
using CQRS_Sample.Persistence.Command.Repositories.SomeModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sima.Framework.Core.Repository;
using SIMA.Framework.Infrastructure.Data;

namespace CQRS_Sample.Persistence.Command.Extensions;

public static class RegisterInfrastructureCommandServicesExtension
{
    public static IServiceCollection RegisterInfrastrucureCommandServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DbContext, CommandDbContext>
            (
                options =>
                    options.UseSqlServer(configuration.GetConnectionString("WriteDB")
             )
        );
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ISomeModelCommandRepository, SomeModelCommandRepository>();
        return services;
    }
}

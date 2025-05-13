using Microsoft.Extensions.Configuration;

namespace CQRS_Sample.Persistence.Query.Extensions;

public static class ConfigurationExtension
{
    public static string GetConnectionString(this IConfiguration configuration)
    {
        return configuration.GetConnectionString("ReadDB") ?? throw new ArgumentNullException("ConnectionString is null !!!");
    }
}

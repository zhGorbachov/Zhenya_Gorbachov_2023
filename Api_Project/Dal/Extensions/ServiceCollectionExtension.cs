using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dal.Extensions;

public static class ServiceCollectionExtension
{
    public static void InjectDatabaseServices(this IServiceCollection services)
    {
        services.AddDatabase();
    }

    private static void AddDatabase(this IServiceCollection services)
    {
    }
}
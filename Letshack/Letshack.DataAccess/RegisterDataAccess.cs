using Microsoft.Extensions.DependencyInjection;

namespace Letshack.DataAccess;

public static class RegisterDataAccess
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        return services;
    }
}
using Letshack.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Letshack.Application;

public static class RegisterApplication
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<AuthService>();
        return services;
    }
}
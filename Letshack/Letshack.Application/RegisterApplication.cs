using Letshack.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Letshack.Application;

public static class RegisterApplication
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<AuthService>();
        services.AddTransient<TechnologyService>();
        services.AddTransient<RelatedTopicService>();
        services.AddTransient<TeamRoleService>();
        services.AddTransient<TagService>();
        services.AddTransient<UserService>();
        return services;
    }
}
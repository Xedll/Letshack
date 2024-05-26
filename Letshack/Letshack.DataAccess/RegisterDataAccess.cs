using Letshack.DataAccess.Repositories;
using Letshack.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Letshack.DataAccess;

public static class RegisterDataAccess
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services.AddTransient<IRelatedTopicStore, RelatedTopicRepository>();
        services.AddTransient<IRoleStore, RoleRepository>();
        services.AddTransient<ITagStore, TagRepository>();
        services.AddTransient<ITechnologyStore, TechnologyRepository>();
        services.AddTransient<IUserStore, UserRepository>();
        services.AddTransient<IUserTechnologyStore, UserTechnologyRepository>();
        return services;
    }
}
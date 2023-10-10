using ChoirManager.Core.Abstractions.Repositories;
using ChoirManager.WebApi.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ChoirManager.WebApi;

public static class ChoirServicesBuilder
{
    public static IServiceCollection AddChoirDependencies(this IServiceCollection services)
    {
        services
            .AddScoped<IChoirRepository, ChoirRepository>()
            .AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
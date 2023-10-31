using ChoirManager.Business.Abstractions;
using ChoirManager.Business.Services;
using ChoirManager.Controllers.Abstractions;
using ChoirManager.Controllers.Controllers;
using ChoirManager.Core.Abstractions.Repositories;
using ChoirManager.WebApi.Repositories;

namespace ChoirManager.WebApi;

public static class ChoirServicesBuilder
{
    public static IServiceCollection AddChoirDependencies(this IServiceCollection services)
    {
        services
            .AddScoped<IChoirRepository, ChoirRepository>()
            .AddScoped<IChoirService, ChoirService>()
            .AddScoped<IChoirController, ChoirController>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IUserController, UserController>();

        return services;
    }
}
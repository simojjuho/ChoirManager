using ChoirManager.Business.Abstractions;
using ChoirManager.Business.Abstractions.Shared;
using ChoirManager.Business.Services;
using ChoirManager.Business.Shared;
using ChoirManager.Controllers.Abstractions;
using ChoirManager.Controllers.Controllers;
using ChoirManager.Core.Abstractions.Repositories;
using ChoirManager.Core.CoreEntities;
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
            .AddScoped<IEntityHelper<Choir>, EntityHelper<Choir>>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IUserController, UserController>()
            .AddScoped<IEntityHelper<User>, EntityHelper<User>>()
            .AddScoped<IChoirUserRepository, ChoirUserRepository>()
            .AddScoped<IChoirUserService, ChoirUserService>()
            .AddScoped<IChoirUserController, ChoirUserController>()
            .AddScoped<IEntityHelper<ChoirUser>, EntityHelper<ChoirUser>>()
            .AddScoped<IChoirUserActions, ChoirUserActions>();

        return services;
    }
}
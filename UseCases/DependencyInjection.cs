using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace UseCases;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        // Add services to the container.
        services.AddScoped<IAccountUseCase, AccountUseCase>();

        return services;
    }
}

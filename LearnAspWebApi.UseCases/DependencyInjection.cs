using LearnAspWebApi.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LearnAspWebApi.UseCases;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(
        this IServiceCollection services
    )
    {
        // Add services to the container.
        services.AddScoped<IAccountUseCase, AccountUseCase>();
        services.AddScoped<IEmployeeUseCase, EmployeeUseCase>();

        return services;
    }
}

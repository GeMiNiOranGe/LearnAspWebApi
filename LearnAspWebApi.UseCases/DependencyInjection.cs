using LearnAspWebApi.Core.Interfaces;
using LearnAspWebApi.UseCases.Mappings;
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

        // Add AutoMapper
        services.AddAutoMapper(typeof(EmployeeProfile).Assembly);

        return services;
    }
}

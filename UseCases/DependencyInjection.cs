using Microsoft.Extensions.DependencyInjection;

namespace UseCases;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        return services;
    }
}

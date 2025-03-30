using Microsoft.Extensions.DependencyInjection;

namespace LearnAspWebApi.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services
    )
    {
        // Add services to the container.

        services.AddControllers();
        return services;
    }
}

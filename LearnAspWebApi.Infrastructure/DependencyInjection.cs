using LearnAspWebApi.Core.Interfaces;
using LearnAspWebApi.Infrastructure.Data;
using LearnAspWebApi.Infrastructure.Mappings;
using LearnAspWebApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LearnAspWebApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services
    )
    {
        services.AddDbContext<LearnAspWebApiContext>(options =>
            options.UseSqlServer("Name=ConnectionStrings:Development")
        );

        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        // Add AutoMapper
        services.AddAutoMapper(typeof(EmployeeProfile).Assembly);

        return services;
    }
}

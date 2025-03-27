using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<LearnAspWebApiContext>(options =>
            options.UseSqlServer("Name=ConnectionStrings:Development"));

        services.AddScoped<IAccountRepository, AccountRepository>();

        return services;
    }
}

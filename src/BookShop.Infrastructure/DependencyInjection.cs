using BookShop.Domain.Interfaces;
using BookShop.Infrastructure.Data;
using BookShop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration
    )
    {
        services.AddDbContext<AppDbContext>(
            options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("BookShop.Infrastructure")
                ));

        services.AddScoped<IBookRepository, BookRepository>();
        return services;
    }
}

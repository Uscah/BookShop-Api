using BookShop.Application.Interfaces;
using BookShop.Application.Mappings;
using BookShop.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        MapsterConfig.RegisterMappings();
        services.AddScoped<IBookService, BookService>();

        return services;
    }
}
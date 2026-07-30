using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataManager.DataContract;

/// <summary>
/// Инжектор в билдер программы
/// </summary>
public static class DataBaseInjection
{
    public static IServiceCollection AddDataBase(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));
        
        return services;
    }
}
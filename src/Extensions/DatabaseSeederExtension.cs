using NextTime.Services;

namespace NextTime.Extensions;

public static class DatabaseSeederExtension
{
    public static IServiceCollection AddDatabaseSeeder(this IServiceCollection services)
    {
        return services.AddScoped<DatabaseSeeder>();
    }
}

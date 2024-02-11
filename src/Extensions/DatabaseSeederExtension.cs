using NextTime.Services;

namespace NextTime.Extensions;

public static class DatabaseSeederExtension
{
    public static IServiceCollection AddDatabaseSeeder(IServiceCollection services)
    {
        return services.AddScoped<DatabaseSeeder>();
    }
}

using NextTime.Services.Managers;

namespace NextTime.Extensions;

public static class ManagersExtension
{
    public static IServiceCollection AddManagers(this IServiceCollection services)
    {
        services.AddScoped<ApplicationUserManager>();
        services.AddScoped<MeetingManager>();
        services.AddScoped<PreferenceManager>();

        return services;
    }
}

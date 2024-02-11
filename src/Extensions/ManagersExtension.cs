using NextTime.Services.Managers;

namespace NextTime.Extensions;

public static class ManagersExtension
{
    public static IServiceCollection AddManagers(this IServiceCollection services)
    {
        services.AddScoped<ApplicationUserManager>();
        services.AddScoped<AppointmentManager>();
        services.AddScoped<ChoiceManager>();
        services.AddScoped<AvailabilityManager>();

        return services;
    }
}

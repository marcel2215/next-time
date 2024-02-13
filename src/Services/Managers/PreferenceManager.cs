using NextTime.Entities;

namespace NextTime.Services.Managers;

public sealed class PreferenceManager(ApplicationDbContext context)
{
    public IQueryable<Preference> Preferences => context.Preferences;

    public async Task CreateAsync(Preference preference)
    {
        await context.Preferences.AddAsync(preference);
        await context.SaveChangesAsync();
    }

    public async Task CreateRangeAsync(IEnumerable<Preference> preference)
    {
        await context.Preferences.AddRangeAsync(preference);
        await context.SaveChangesAsync();
    }

    public async Task<Preference?> FindByIdAsync(Guid id)
    {
        return await context.Preferences.FindAsync(id);
    }

    public async Task UpdateAsync(Preference preference)
    {
        context.Preferences.Update(preference);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Preference preference)
    {
        context.Preferences.Remove(preference);
        await context.SaveChangesAsync();
    }
}

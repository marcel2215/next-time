using NextTime.Entities;

namespace NextTime.Services.Managers;

public sealed class AvailabilityManager(ApplicationDbContext context)
{
    public IQueryable<Availability> Availabilities => context.Availabilities;

    public async Task CreateAsync(Availability availability)
    {
        await context.Availabilities.AddAsync(availability);
        await context.SaveChangesAsync();
    }

    public async Task<Availability?> FindByIdAsync(Guid id)
    {
        return await context.Availabilities.FindAsync(id);
    }

    public async Task UpdateAsync(Availability availability)
    {
        context.Availabilities.Update(availability);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Availability availability)
    {
        context.Availabilities.Remove(availability);
        await context.SaveChangesAsync();
    }
}

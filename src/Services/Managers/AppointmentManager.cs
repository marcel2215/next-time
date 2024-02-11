using NextTime.Entities;

namespace NextTime.Services.Managers;

public sealed class AppointmentManager(ApplicationDbContext context)
{
    public IQueryable<Appointment> Appointments => context.Appointments;

    public async Task CreateAsync(Appointment appointment)
    {
        await context.Appointments.AddAsync(appointment);
        await context.SaveChangesAsync();
    }

    public async Task<Appointment?> FindByIdAsync(Guid id)
    {
        return await context.Appointments.FindAsync(id);
    }

    public async Task UpdateAsync(Appointment appointment)
    {
        context.Appointments.Update(appointment);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Appointment appointment)
    {
        context.Appointments.Remove(appointment);
        await context.SaveChangesAsync();
    }
}

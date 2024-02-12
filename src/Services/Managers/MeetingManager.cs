using NextTime.Entities;

namespace NextTime.Services.Managers;

public sealed class MeetingManager(ApplicationDbContext context)
{
    public IQueryable<Meeting> Meetings => context.Meetings;

    public async Task CreateAsync(Meeting meeting)
    {
        await context.Meetings.AddAsync(meeting);
        await context.SaveChangesAsync();
    }

    public async Task<Meeting?> FindByIdAsync(Guid id)
    {
        return await context.Meetings.FindAsync(id);
    }

    public IQueryable<Declaration> GetDeclarations(Meeting meeting)
    {
        return context.Declarations.Where(d => d.MeetingId == meeting.Id);
    }

    public async Task UpdateAsync(Meeting meeting)
    {
        context.Meetings.Update(meeting);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Meeting meeting)
    {
        context.Meetings.Remove(meeting);
        await context.SaveChangesAsync();
    }
}

using Microsoft.EntityFrameworkCore;
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

    public async Task<Meeting?> FindByCodeAsync(string code)
    {
        return await context.Meetings.FirstOrDefaultAsync(m => m.Code == code);
    }

    public IQueryable<Preference> GetPreferences(Guid meetingId)
    {
        return context.Preferences.Where(p => p.MeetingId == meetingId);
    }

    public IQueryable<Preference> GetPreferences(Guid meetingId, Guid userId)
    {
        return context.Preferences.Where(p => p.MeetingId == meetingId && p.UserId == userId);
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

    public async Task DeletePreferencesAsync(Guid meetingId, Guid userId)
    {
        await context.Preferences.Where(p => p.MeetingId == meetingId && p.UserId == userId).ExecuteDeleteAsync();
    }
}

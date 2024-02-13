using NextTime.Entities;

namespace NextTime.Services.Managers;

public sealed class SuggestionManager(ApplicationDbContext context)
{
    public IQueryable<Suggestion> Suggestions => context.Suggestions;

    public async Task CreateAsync(Suggestion suggestion)
    {
        await context.Suggestions.AddAsync(suggestion);
        await context.SaveChangesAsync();
    }

    public async Task CreateRangeAsync(IEnumerable<Suggestion> suggestions)
    {
        await context.Suggestions.AddRangeAsync(suggestions);
        await context.SaveChangesAsync();
    }

    public async Task<Suggestion?> FindByIdAsync(Guid id)
    {
        return await context.Suggestions.FindAsync(id);
    }

    public async Task UpdateAsync(Suggestion suggestion)
    {
        context.Suggestions.Update(suggestion);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Suggestion suggestion)
    {
        context.Suggestions.Remove(suggestion);
        await context.SaveChangesAsync();
    }
}

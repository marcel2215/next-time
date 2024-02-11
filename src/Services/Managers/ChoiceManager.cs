using NextTime.Entities;

namespace NextTime.Services.Managers;

public sealed class ChoiceManager(ApplicationDbContext context)
{
    public IQueryable<Choice> Choices => context.Choices;

    public async Task CreateAsync(Choice choice)
    {
        await context.Choices.AddAsync(choice);
        await context.SaveChangesAsync();
    }

    public async Task<Choice?> FindByIdAsync(Guid id)
    {
        return await context.Choices.FindAsync(id);
    }

    public async Task UpdateAsync(Choice choice)
    {
        context.Choices.Update(choice);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Choice choice)
    {
        context.Choices.Remove(choice);
        await context.SaveChangesAsync();
    }
}

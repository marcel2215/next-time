using NextTime.Entities;

namespace NextTime.Services.Managers;

public sealed class DeclarationManager(ApplicationDbContext context)
{
    public IQueryable<Declaration> Declarations => context.Declarations;

    public async Task CreateAsync(Declaration declaration)
    {
        await context.Declarations.AddAsync(declaration);
        await context.SaveChangesAsync();
    }

    public async Task<Declaration?> FindByIdAsync(Guid id)
    {
        return await context.Declarations.FindAsync(id);
    }

    public async Task UpdateAsync(Declaration declaration)
    {
        context.Declarations.Update(declaration);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Declaration declaration)
    {
        context.Declarations.Remove(declaration);
        await context.SaveChangesAsync();
    }
}

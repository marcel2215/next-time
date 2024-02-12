using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using NextTime.Constants;
using NextTime.Entities;
using NextTime.Exceptions;

namespace NextTime.Services.Managers;

public sealed class ApplicationUserManager(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
{
    public IQueryable<ApplicationUser> Users => userManager.Users;

    public async Task CreateAsync(ApplicationUser user)
    {
        using var transaction = context.Database.BeginTransaction();
        try
        {
            var result = await userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                throw new IdentityException(result);
            }

            await AddToRoleAsync(user, RoleNames.User);
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<ApplicationUser?> GetAsync(ClaimsPrincipal principal)
    {
        return await userManager.GetUserAsync(principal);
    }

    public IQueryable<Meeting> GetMeetings(ApplicationUser user)
    {
        return context.Meetings.Where(m => m.UserId == user.Id);
    }

    public IQueryable<Declaration> GetDeclarations(ApplicationUser user)
    {
        return context.Declarations.Where(d => d.UserId == user.Id);
    }

    public async Task<ApplicationUser?> FindByIdAsync(Guid id)
    {
        return await userManager.FindByIdAsync(id.ToString());
    }

    public async Task<ApplicationUser?> FindByNameAsync(string userName)
    {
        return await userManager.FindByNameAsync(userName);
    }

    public async Task UpdateAsync(ApplicationUser user)
    {
        var result = await userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            throw new IdentityException(result);
        }
    }

    public async Task AddToRoleAsync(ApplicationUser user, string role)
    {
        var result = await userManager.AddToRoleAsync(user, role);
        if (!result.Succeeded)
        {
            throw new IdentityException(result);
        }
    }

    public async Task RemoveFromRoleAsync(ApplicationUser user, string role)
    {
        var result = await userManager.RemoveFromRoleAsync(user, role);
        if (!result.Succeeded)
        {
            throw new IdentityException(result);
        }
    }

    public async Task DeleteAsync(ApplicationUser user)
    {
        var result = await userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            throw new IdentityException(result);
        }
    }
}

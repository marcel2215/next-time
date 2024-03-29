using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

    public async Task<ApplicationUser?> FindByIdAsync(Guid id, bool asNoTracking = false)
    {
        return asNoTracking
            ? await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id)
            : await userManager.FindByIdAsync(id.ToString());
    }

    public IQueryable<Meeting> GetCreatedMeetings(ApplicationUser user)
    {
        return context.Meetings.Where(m => m.UserId == user.Id);
    }

    public IQueryable<Meeting> GetSharedMeetings(ApplicationUser user)
    {
        return context.Meetings.Where(m => m.UserId != user.Id && m.Preferences.Any(p => p.UserId == user.Id));
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

    public async Task SetDisplayNameAsync(ApplicationUser user, string displayName)
    {
        user.DisplayName = displayName.Trim();
        await UpdateAsync(user);
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
